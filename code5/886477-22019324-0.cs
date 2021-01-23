    double purchase;
    double total = 0;
    string inputString;
    const double QUIT = 0;
    for (int i = 1; i <= 5; i++)
    {
        Console.Write("Enter a purchase amount >> ");
        inputString = Console.ReadLine();
        purchase = Convert.ToDouble(inputString);
        if(purchase == QUIT)
            break;
        
        total += purchase;
        Console.Write("Enter another purchase amount or " + QUIT + " to calculate >> "); //I only want this to appear 4 more times\\
        inputString = Console.ReadLine();
        purchase = Convert.ToDouble(inputString);
    }
        
