    ...
    static void Main(string[] args) {
      String userValue;
    
      // If you want to ask user once only, uncomment this line, otherwise comment it out  
      // Console.WriteLine("Type a sentence without using the letter T or a question 
      while (true) {
        // If you want to ask user any time he/she puts wrong sentence, uncomment this line, otherwise comment it out  
        Console.WriteLine("Type a sentence without using the letter T or a question mark.");
        userValue = Console.ReadLine();
    
        if (userValue.Contains('T')) 
          Console.WriteLine("Invalid, contains 'T'");
        else if (userValue.Contains('t')) 
          Console.WriteLine("Invalid, contains 't'");
        else if (userValue.Contains('?')) 
          Console.WriteLine("Invalid, contains '?'");
        else
          break;       
      }
    
      Console.WriteLine("Valid, doesn't contain 'T', 't', '?'");
    }
    ...
