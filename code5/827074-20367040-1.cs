    public int DisplayMenu()
    {   
      Console.WriteLine("Football Manager");
      Console.WriteLine();
      Console.WriteLine("1. Add a Football team");
      Console.WriteLine("2. List the Football teams");
      Console.WriteLine("3. Search for a Football team");
      Console.WriteLine("4. Delete a team");
      Console.WriteLine("5. Exit");
      var result = Console.ReadLine();
      return Convert.ToInt32(result);
    }
