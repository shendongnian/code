    Console.WriteLine("Please enter a letter");
    string input;
    while(true)
    {
      input = Console.ReadLine();
      if (input.Length == 1) { break; }
      Console.WriteLine("Invalid input");        
    }
      
    char guess = input[0];
