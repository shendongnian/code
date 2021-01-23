        //get numberServed
        numberServed = Console.ReadLine();
        if (inputString == Pizza.Name)
       {
           Pizza.PrintFoodProfile();
           totalCost = numberServed * Pizza.Cost;
       }
       else if (inputString == Burger.Name)
       {
           Burger.PrintFoodProfile();
           totalCost = numberServed * Pizza.Cost;
        }
    	Console.WriteLine("The total cost is: £" + totalCost);
        Console.WriteLine();
