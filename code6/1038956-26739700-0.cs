      Console.WriteLine("Enter something:");
      string input = Console.ReadLine();       // for example ABC123
      Func<bool> anyDigits = () => input.Any(Char.IsDigit);  // will capture 'input' as a field
      while (anyDigits())
      {
        Console.WriteLine("Enter a string which doesn't contain digits");
        input = Console.ReadLine();         // for example ABC
      }
      Console.WriteLine("Bye");
      Console.ReadLine();
