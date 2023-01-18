using System;
using System.Collections.Generic;
using System.IO;

namespace wordle
{
    class Wordle
    {
        string word { get; set; }
        int pokus;
        string guess { get; set; }
        Random ran = new Random();
        string[] slovnik = File.ReadAllLines("valid-wordle-words.txt");


        void GenerateWord()
        {
            
            int index = ran.Next(slovnik.Length);
            word = slovnik[index];
        }

        void CheckInput(string guess2)
        {
            guess = guess2;
            pokus = pokus + 1;
            string output = ""; 
            foreach(char pismeno in guess)
            {
                if (word.Contains(pismeno.ToString()))
                {
                    if(guess.IndexOf(pismeno) == word.IndexOf(pismeno))
                    {   
                        output = output + "O";
                    }
                    else
                    {
                        output = output + "o";
                    }
                }
                else
                {
                    output = output + "x";
                }
            }

            Console.WriteLine(output);
        }

        public void StartGame()
        {
            Console.WriteLine("x ... špatně \no ... správně písmeno, ale na špatném indexu \nO ... správně písmeno i umístění");

            GenerateWord();

            while(pokus < 6)
            {
                if(guess == word)
                {
                    Console.WriteLine("Nádhera");
                    break;
                }   
                CheckInput(Console.ReadLine());
            }

            if(guess != word)
            {
                TellSolution();
            }
            
        }

        void TellSolution()
        {
            Console.WriteLine("No bída, bylo to" + word);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Wordle hra = new Wordle();
            hra.StartGame();
        }
    }
}
