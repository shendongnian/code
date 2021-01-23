    List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
    ..
    ..
    
    // some function called at startup to read the entire file in the collection
    private void LoadData()
    {
        var reader = new StreamReader(File.OpenRead(@"C:\dictionary.csv"));
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(';');
            var kvp = new KeyValuePair<string, string>(values[0], values[1]);
            items.Add(kvp);
        }
    
    }
    
    
    private string SearchWord(string inputWord)
    {
       string returnValue = string.Empty;
       foreach(var currentItem in items)
       {
          if (string.Equals(inputWord, currentItem, StringComparison.OrdinalIgnoreCase))
          {
             returnValue = currentItem.Value;
             break;
          }
       }
       
       return returnValue;
    }
