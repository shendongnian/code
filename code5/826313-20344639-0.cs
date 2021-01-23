        struct Player
            {
                public string Name;
                public int X;
                public int Y;
            }
            static Player[] players = new Player[amountofPlayers];
        
        
            static void ResetGame() {
                Console.WriteLine("Welcome to the game!");
                Console.Write("How many player will be taking part today: ");
                string playerNo = Console.ReadLine();
                amountofPlayers = int.Parse(playerNo);
             Array.Resize(ref  players, amountofPlayers ); /// this will resize your array element to the accepted amount of player
                    if (amountofPlayers <= 4)
                    {
                        for (int i = 0; i < amountofPlayers; i = i + 1)
                        {
                            int displayNumber = i + 1;
                            Console.Write("Please enter the name of player " + displayNumber + ": ");
                            players[i].Name = Console.ReadLine(); //error is here
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number of players less than 4!");
                    }
            }
        
            static int amountofPlayers;
