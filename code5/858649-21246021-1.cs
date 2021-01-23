    public void manyPlay() {
        string input; // declare local variable
        myCraps.play();
        while(true) {
            Console.Write("Would you like to play again? y/n");
            input = Console.ReadLine();
            if (input == "y") {
                myCraps.play();
            }
            else if (input == "n") {
                break;
            }
            else {
                Console.WriteLine("\n Erroneous input. Please enter y (yes) or n (no)");
            }
        }
       
    } 
