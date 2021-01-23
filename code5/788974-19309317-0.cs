    do
    {
        //Bunch of code
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
    } while (playAgain == 'y' || playAgain == 'Y');
