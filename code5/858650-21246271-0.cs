    using System;
    
    namespace Task4_7
    {
        public class CrapsGame
        {  
            public static void Main()
            {
                new Craps ().play ();
                new CrapsGame().manyPlay ();
            }
    
            public void manyPlay() {
                string replay;
                string input; // declare local variable
                do {
                    new Craps().play();
                    replay:
                    Console.Write("Would you like to play again? y/n");
                    input = Console.ReadLine();
                    if (input == "y") {
                        replay = input;
                    }
                    else if (input == "n") {
                        replay = "n";
                    }
                    else {
                        Console.WriteLine("\n Erroneous input. Please enter y (yes) or n (no)");
                        goto replay;
                    }
                }
                while(replay != "n");
            } 
        }
    }
