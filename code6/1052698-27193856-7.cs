        if (inputString == Pizza.Name)
       {
           Pizza.PrintFoodProfile();
    	   //get NumberServed
    	   Pizza.NumberServed = Console.ReadLine();
           totalCost = Pizza.NumberServed * Pizza.Cost;
       }
       else if (inputString == Burger.Name)
       {
           Burger.PrintFoodProfile();
    	   //get NumberServed
    	   Burger.NumberServed = Console.ReadLine();
           totalCost = Burger.NumberServed * Burger.Cost;
        }
    	Console.WriteLine("The total cost is: £" + totalCost);
