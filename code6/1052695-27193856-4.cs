     while (inputString == "" || inputString == Pizza.Name)
      {
          inputString = Console.ReadLine();
          Console.WriteLine();
    
          if (inputString == Pizza.Name)
          {
              Pizza.PrintFoodProfile();
              totalCost = totalCost + Pizza.Cost;
              Console.WriteLine("The total cost is: £" + totalCost);
              Console.WriteLine();
          }
      }
