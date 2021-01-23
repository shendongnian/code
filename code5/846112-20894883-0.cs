    class OverUnder
    {
        string playAgain = "";
    
        Random random = new Random();
    
        public OverUnder()
        {
            randomNumber = random.Next(1, 101);
        }
    
        int randomNumber = 0;
        int bestScore = int.MaxValue;
        int guess = 1;
        int userGuess;
    
    
        public string playerGuess()
        {
            Console.WriteLine("Guess a number from 1 - 100");
            string playerGuess = Console.ReadLine();
            return playerGuess;
        }
    
        public string userPlayAgain()
        {
            Console.WriteLine("Do you want to play again? Yes or No");
            string userPlayAgain = Console.ReadLine();
            return userPlayAgain;
        }
    
        public void playGame()
        {
    
            Console.WriteLine(randomNumber);
    
            do
            {
                userGuess = Convert.ToInt32(playerGuess());
    
    
                if (randomNumber > userGuess)
                {
                    Console.WriteLine("Your guess is LOW");
                    Console.WriteLine("# of guesses: " + guess);
                    Console.WriteLine("Best score: " + guess);
                    guess++;
                    Console.ReadLine();
                }
    
                else if (randomNumber < userGuess)
                {
                    Console.WriteLine("Your guess is HIGH");
                    Console.WriteLine("# of guesses: " + guess);
                    Console.WriteLine("Best score: " + guess);
                    guess++;
                    Console.ReadLine();
                }
    
                if (userGuess == randomNumber)
                {
                    if (guess < bestScore)
                        bestScore = guess;
    
                    Console.WriteLine("You got it! Congratulations, You Win!");
                    Console.WriteLine("# of guesses: " + guess);
                    Console.WriteLine("Best score: " + bestScore);
                    Console.ReadLine();
                    playAgain = userPlayAgain();
                }
            } while (userGuess != randomNumber || playAgain == "Yes");
        }
    }
