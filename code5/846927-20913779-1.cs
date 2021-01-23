    if(Int32.TryParse(Console.ReadLine(), out mainMenuChoice))
    {
        if (mainMenuChoice == 1)
        {
             ......
        }
        .... etc ....
        else
        {
            Console.WriteLine("you didnt enter a valid input! try again.");
        }
    }
    else
    {
        Console.WriteLine("you didnt enter a valid input! try again.");
    }
