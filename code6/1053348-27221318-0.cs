                Player player = new Player();
                try
                {
                    player = new Player(number, firstName, lastName, goals, assists);
                    //or assign individually instead of using the constructor
                    //if your player class allows it
                    players[insertIndex] = player;
    
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
