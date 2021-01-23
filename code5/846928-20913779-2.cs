    if(Int32.TryParse(Console.ReadLine(), out mainMenuChoice))
    {
        if (mainMenuChoice == 1)
            Option1();
        else if (mainMenuChoice == 2)
            Option2();
        else if (mainMenuChoice == 3)
            Option3();
        else if (mainMenuChoice == 4)
            Option4();
        else
            Console.WriteLine("you didnt enter a valid input! try again.");
    }
    else
    {
        Console.WriteLine("you didnt enter a valid input! try again.");
    }
