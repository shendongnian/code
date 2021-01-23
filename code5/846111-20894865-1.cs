        if (userGuess == randomNumber)
            {
                if (guess < bestScore)
                    bestScore = guess;
                Console.WriteLine("You got it! Congratulations, You Win!");
                Console.WriteLine("# of guesses: " + guess);
                Console.WriteLine("Best score: " + bestScore.Value);
                Console.ReadLine();
                playAgain = userPlayAgain();
                guess = 1;
            }
