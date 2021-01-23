    private static void Main(string[] args)
    {
      Console.WriteLine("Insert 3 letter name containing 'A'");
      string userInput = Console.ReadLine();
      string yourCharacter = "m";
      userInput = UpperCharacter(userInput, yourCharacter);
    }
    private static string UpperCharacter(string srcString, string characterToReplace)
    {
      // Check for empty string.
      if (string.IsNullOrEmpty(srcString))
      {
        Console.WriteLine("Please insert a name");
      }
      // Return char and concat substring.
      return srcString.Replace(characterToReplace, characterToReplace.ToUpper());
    }
