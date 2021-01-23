           int gessNum = 0;
           do
           {
                if (gessNum++ == maxGuesses){
                    Console.WriteLine("You lost");
                    break;
                }
                Console.WriteLine(string.Format(" Enter Guess {0}: ", gessNum));
                currentGuess = Int32.Parse(Console.ReadLine());
                if (currentGuess == randomNumber)
                {
                    Console.WriteLine("You got it!");
                }
                if (currentGuess > randomNumber)
                {
                    Console.WriteLine("Too High");
                }
                if (randomNumber > currentGuess)
                {
                    Console.WriteLine("Too Low");
                }
                Console.ReadLine();
            } while (currentGuess != randomNumber);
