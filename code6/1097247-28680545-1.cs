    static void Main(string[] args)
    {
        Console.WriteLine("Please enter the number of your favorite color out of the following choices. \n Where 1 = Red \n 2 = Orange \n 3 = Green \n 4 = Blue \n 5 = Indigo \n 6 = Violet");
        string userChoice = Console.ReadLine();
        Color? favorite = null;
        if (userChoice == "1")
        {
            favorite = Color.Red;
        }
        if (userChoice == "2")
        {
            favorite = Color.Orange;
        }
        if (userChoice == "3")
        {
            favorite = Color.Green;
        }
        if (userChoice == "4")
        {
            favorite = Color.Blue;
        }
        if (userChoice == "5")
        {
            favorite = Color.Indigo;
        }
        if (userChoice == "6")
        {
            favorite = Color.Violet;
        }
        switch (userChoice)
        {
            case "1":
                Console.WriteLine("You chose Red");
                break;
            case "2":
                Console.WriteLine("You chose Orange");
                break;
            case "3":
                Console.WriteLine("You chose Green");
                break;
            case "4":
                Console.WriteLine("You chose Blue");
                break;
            case "5":
                Console.WriteLine("You chose Indigo");
                break;
            case "6":
                Console.WriteLine("You chose Violet");
                break;
            default:
                Console.WriteLine("You didn't choose a color");
                break;
        }
        Console.ReadKey(true);
    }
