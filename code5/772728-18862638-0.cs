    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
     namespace ConsoleApplication2
    {
    public class Program
    {
        int numberToGuess;
        int numberGuessed;
        int triesRemaining = 7;
        string playAgain;
        string player1, player2;
        public void game()                                                                                                              //Initiates the game instance
            {
                Console.WriteLine("           ==Welcome to Guess My Number== \n");
                Console.WriteLine(" Player 1, Please enter your name: \n");
                player1 = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("                      ==Guess My Number== \n");
                Console.WriteLine("Hello " + player1 + " : Please enter your number to guess between 1 and 20: \n");
                numberToGuess = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("           ==Guess My Number== \n");
                Console.WriteLine(" Player 2, Please enter your name: \n");
                player2 = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Hello " + player2 + " please enter your first guess, you have 7 tries: \n");
                numberGuessed = int.Parse(Console.ReadLine());
                if (numberGuessed == numberToGuess)
                {
                    Console.WriteLine("Congratulations, the number was in fact " + numberToGuess);
                    newGame();
                }
                else
                {
                    incorrect();
                }
                   
            }
        public void incorrect()                                                                                                         //Method for dealing with incorrect answers
        {
            for (int x = 0; x < 6; x++)
            {
                triesRemaining--;
                Console.WriteLine("Incorrect, you have " + triesRemaining + " tries remaining \n");
                Console.WriteLine(player2 + ", please enter your next guess: \n");
                numberGuessed = int.Parse(Console.ReadLine());
                if (numberGuessed == numberToGuess)
                {
                    Console.WriteLine("Congratulations, the number was in fact " + numberToGuess);
                    newGame();
                }
                else { 
                    //Do nothing
                }
                
            }
            Console.WriteLine("You have used up all your tries! You have failed. The number was: " +numberToGuess + "\n");
            newGame();
        }                                                      //Method for dealing with incorrect answers
        public void newGame()                                                                                                           //Method that gives the user the option to start a new game instance
        {
            Console.WriteLine("Would you like to play again? Type yes or no: \n");
            playAgain = Console.ReadLine();
            playAgain = playAgain.ToLower();
            if (playAgain == "yes")
            {
                Console.Clear();
                game();
            }
            else if (playAgain == "y")
            {
                game();
            }
            else
            {
                //Do nothing
            }
        }                                                        
       static void  Main(string[] args)
        {
            new Program().game();
            
        }
    }
    }
