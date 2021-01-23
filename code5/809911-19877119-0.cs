    string[] lines = File.ReadAllLines(@"C:\Users\Public\TestFolder\Text.txt");            
    foreach(string word in lines)
    {
       if (word.StartsWith("(long)", StringComparison.InvariantCulture) && word.EndsWith(';', StringComparison.InvariantCulture))
       {
          //Replace your string here.
       }
    }
