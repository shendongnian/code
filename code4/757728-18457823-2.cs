    ...
    static void Main(string[] args) {
      Console.WriteLine("Type a sentence without using the letter T or a question mark.");
      String userValue = Console.ReadLine();
    
      if (userValue.Contains('T')) 
        Console.WriteLine("Invalid, contains 'T'");
      else if (userValue.Contains('t')) 
        Console.WriteLine("Invalid, contains 't'");
      else if (userValue.Contains('?')) 
        Console.WriteLine("Invalid, contains '?'");
      else
        Console.WriteLine("Valid, doesn't contain 'T', 't', '?'");
    }
    ...
