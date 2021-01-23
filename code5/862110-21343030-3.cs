    Dictionary<string, int> countDictionary = new Dictionary<string, int>(); // case sensitive!
    string GetNameForItem(string itemName)
    {
      var name = itemName;
      var count = 0;
      countDictionary.TryGetValue(itemName, out count);
    
      if (count > 0)
        name = string.Format("{0} - {1}", itemName, count);
      
      countDictionary[itemName] = count + 1;
      return name;
    }
