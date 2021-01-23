        public static void SomeMethod()
        {
            Console.Write("\nWrite H/h to guess Heads, T/t to guess Tails, or Q/q to quit =>  ");
            char userChoice;
            int numWins = 0;
            int numPlays = 0;
            double percentWin = 0d;
            while ((userChoice = Convert.ToChar(Console.ReadLine())).ToString().ToLower() != "q")
            {
                numPlays++;
                int compChoice = new Random().Next(2);
                if (userChoice == 'H' || userChoice == 'h')
                {
                    if (compChoice == 0)
                    {
                        Console.WriteLine("\nYOU WON");
                        numWins++;
                    }
                    else
                    {
                        Console.WriteLine("\nYOU LOSE");
                    }
                    continue;
                }
                if (userChoice == 'T' || userChoice == 't')
                {
                    if (compChoice == 1)
                    {
                        Console.WriteLine("\nYOU WON");
                        numWins++;
                    }
                    else
                    {
                        Console.WriteLine("\nYOU LOSE");
                    }
                    continue;
                }                        
            }
            if (numPlays != 0)
            {
                percentWin = (double)numWins / numPlays;
            }
            Console.WriteLine("\nYou won {0} out of {1} game(s) or {2:P} of the games played.", numWins, numPlays, percentWin);
            Console.ReadKey();
        }
