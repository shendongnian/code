    // Here we make use of a nullable.
    // since the user hasn't enter any color yet the value of color is null.  
    Color? color = null;
    // Here we ask the user to enter his choice.
    string userChoice = Console.ReadLine();
    Console.WriteLine("Please enter the number of your favorite color out of the following choices. /n Where 1 = Red /n 2 = Orange /n 3 = Green /n 4 = Blue /n 5 = Indigo /n 6 = Violet");
    // According to users input, we set the corresponding color.
    // If not a correct color entered, then the value of color would stay null.
    if (userChoice == "1")
    {
        color = Color.Red;
    }
    if (userChoice == "2")
    {
        color = Color.Green;
    }
    if (userChoice == "3")
    {
        color = Color.Blue;
    }
    if (userChoice == "4")
    {
        color = Color.Blue;
    }
    switch (color)
    {
        case Color.Red:
            Console.WriteLine("You chose Red");
            break;
        case Color.Green:
            Console.WriteLine("You chose Green");
            break;
        case Color.Blue:
            Console.WriteLine("You chose Blue");
            break;
        case Color.Orange:
            Console.WriteLine("You chose Orange");
            break;
        case null:
            Console.WriteLine("You didn't choose a color");
            break;
        default:
            Console.WriteLine("You didn't choose a color");
            break;
    }
