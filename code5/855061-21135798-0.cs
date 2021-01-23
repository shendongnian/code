    static void playAgainMsg(String message)
            {
                Console.WriteLine(message + "Do you want to play again? Y/N"); 
                if (Console.ReadLine().Equals("Y"))
                {
                    strPlaysAgain = "Y";
                    introduction();
                }   
                else
                {
                    strPlaysAgain = "N"; 
                    Console.Clear(); removed.
                    MainMenu();  
                }
            }
