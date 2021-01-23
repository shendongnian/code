    // While loop usually read better: keep on asking again and again until 
    // valid value is chosen
    while (true) {
      Console.Write("Enter a 'D' to Deposit, 'W' to Withdrawl, or 'X' to End the program: ");
      String userInput = Console.ReadLine(); // <- You don't need any Convert here
    
      // Try not use ".ToUpper" - move it to comparison: StringComparison.OrdinalIgnoreCase
      if (String.Equals(userInput, "D", StringComparison.OrdinalIgnoreCase)) {
        Console.Write("You've selected 'D'");
    
        break;
      }
      else if (String.Equals(userInput, "W", StringComparison.OrdinalIgnoreCase)) {
        Console.Write("You've selected 'W'");
    
        break;
      }
      else if (String.Equals(userInput, "X", StringComparison.OrdinalIgnoreCase)) {
        Console.Write("You've selected 'X'");
    
        break;
      }
    
      Console.WriteLine();
      Console.WriteLine("You've written an invalid option.");
    }
