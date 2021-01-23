    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                int correctcounter = 0;
                int wrongcounter = 0;
                char l1 = 'j';
                char l2 = 'o';
                char l3 = 'h';
                char l4 = 'n';
                char l5 = 's';
                char[] correctletters = { 'j', 'o', 'h', 'n', 's', 'o', 'n' };
                char[] wordToReveal = {'*', '*', '*', '*', '*', '*', '*'};
                char[] guessedletters = new char[10];
                Console.WriteLine("Welcome to the Hangman Game!");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("You have 10 tries to guess the word right.");
                Console.WriteLine();
                Console.WriteLine();
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("The word is " + string.Concat(wordToReveal) + ".");
                    Console.WriteLine();
                    Console.WriteLine("Guessed letters: [{0}]", string.Join(",", guessedletters));
                    Console.WriteLine();
                    Console.WriteLine("Your total wrong guesses:{0}.", wrongcounter);
                    Console.WriteLine();
                    Console.WriteLine("Please enter a letter");
                    Console.WriteLine();
                    guessedletters[i] = Convert.ToChar(Console.ReadLine());
                    if (guessedletters[i] == l1 || guessedletters[i] == l2 || guessedletters[i] == l3 || guessedletters[i] == l4 || guessedletters[i] == l5)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You guessed correctly!");
                        for (int j = 0; j < correctletters.Length; j++)
                        {
                            if (guessedletters.Contains(correctletters[j]))
                            {
                                wordToReveal[j] = correctletters[j];
                            }
                        }
                        correctcounter++;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("You guessed incorrectly");
                        wrongcounter++;
                    }
                    if (correctcounter == 5)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You guessed the word, [{0}]. You WIN!", string.Concat(correctletters));
                        break;
                    }
                    if (wrongcounter == 10)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You LOSE! The word was [{0}]. You LOSE!", string.Concat(correctletters));
                        break;
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Please hit enter to end the program");
                Console.ReadLine();
            }
        }
    }
