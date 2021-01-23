    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication3
    {
        class Program
        {
             static void Main(string[] args)
             {
                        // SETUP SESSION
                        // Declare variables
                        Int32 currentGuess, upperLimit, randomNumber;
                        double maxGuesses;
                        char playAgain = 'n';
                        Random random = new Random();
    
    			// WELCOME THE USER
    			Console.WriteLine("Welcome to the high/low guessing game.");
    
    			//INITILIZE WIN COUNT AND GAME COUNT
    
    			Int32 gameCount = 0, winCount = 0;
    
    			//DO LOOP #1
                do
                //SETUP GAME
                {
                    //REQUEST USER FOR UPPER LIMIT
                    Console.WriteLine("Enter Upper range (e.g. 100):");
                    upperLimit = Int32.Parse(Console.ReadLine());
    
                    //INITILIZE GUESS COUNT
                    Int32 guessCount = 0;
                    bool gameOver = false;
    
                    //DETERMINE RANDOM NUMBER
                    randomNumber = random.Next(1, upperLimit);
                    //DETERMINE MAX GUESSES
                    maxGuesses = Math.Ceiling(Math.Log(upperLimit, 2) - 1);
    
                    // INFORM USER RANDOM NUMBER IS CHOSEN AND INDICATE NUMBER OF GUESSES ALLOWED 
                    Console.WriteLine("I picked a number between 1 and {0} you get {1} chances to guess it", upperLimit, maxGuesses);
    
                    //DO LOOP #2
                    do
                    {
                        //PLAY GAME
                        //READ GUESSES
                        Console.WriteLine(string.Format(" Enter Guess {0}: ", guessCount));
                        currentGuess = Int32.Parse(Console.ReadLine());
                        if (currentGuess == randomNumber)
                        {
                            //INCRIMENT WIN COUNT
                            winCount++;
                        }
                        if (currentGuess == randomNumber)
                        {
                            Console.WriteLine("You got it!");
                            gameOver = true;
                            gameCount++;
                        }
                        else if (currentGuess > randomNumber)
                        {
                            Console.WriteLine("Too High");
                        }
                        else if (currentGuess < randomNumber)
                        {
                            Console.WriteLine("Too Low");
                        }
    
    
                    } while (guessCount < maxGuesses && gameOver == false);
    
                    //POST PROCESSING GAME
    
                    if (guessCount++ == maxGuesses)
                    {
                        //INCRIMENT GAME COUNT
                        gameCount++;
                        Console.WriteLine("You lost");
                        //DISPLAY CORRECT NUMBER IF TOO MANY INCORRECT GUESSES
                        Console.WriteLine("\nThe number was {0},better luck next time!", randomNumber);
                        guessCount = 1;
    
                        //PROMPT TO PLAY AGAIN
    
                        Console.WriteLine("Would you like to play again? (Y/N)");
                        playAgain = char.Parse(Console.ReadLine());
    
    
                    }
                } while (playAgain == 'y' || playAgain == 'Y');
    
    			// display win count 
    			Console.WriteLine("Thanks for playing, you won {0} out of {1} games", winCount, gameCount);
    			Console.ReadLine();
    	   }
    	}
    }
