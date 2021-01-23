    List<char> characters = new List<char>() { 'A', 'C', 'T', 'F', 'B', 'O' };
    List<string> dictionary = new List<string>() { "CAT", "ACT", "A", "FISH", "BONE" };
    List<string> possibleWords = new List<string>();
    
    foreach (string word in dictionary)
    {
       if (!(word.ToLower().Except(characters.ToString().ToLower()).Any()))
       {
          possibleWords.Add(word);
       }
    }
    // Result: "CAT", "ACT", "A"
