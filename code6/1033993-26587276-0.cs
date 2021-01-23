            while (continueRunning)
            {
                int howMany = int.Parse(getInfo("How many times do you want to roll the die?"));
                Dice aDice = new Dice();
                for(int i = 0; i < howMany; i++)
                {
                    aDice.RollDice();
                }
                Console.Clear();
                Console.WriteLine("Session Number: {0}", sessionNumber);
                Console.WriteLine(aDice);
                continueRunning = getYorN("Would you like to run again?");
                sessionNumber++;
                Console.Clear();
            }
