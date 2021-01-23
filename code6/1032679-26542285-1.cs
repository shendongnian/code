      String input;
    
      do {
        Console.WriteLine("Please enter student number:");
        input = Console.ReadLine();
      }
      while (!Regex.IsMatch(input, @"^\d{5}$")); // <- five digits expected
          
      // input contains 5 digit string
      int number = int.Parse(number);  
