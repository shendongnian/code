    Console.WriteLine("type 'q' to quit");
    while (true)
    {
      string input = Console.ReadLine();
      if (input == "q")
      {
        break;
      }
      else
      {
        Console.WriteLine("You entered '{0}'", input);
      }
    }
