    Dictionary<string, int> firstNames = new Dictionary<string, int>();
    
    foreach (string name in YourListWithNames)
    {
       if (!firstNames.ContainsKey(name))
          firstNames.Add(name, 1);
       else
          firstNames[name] += 1; 
    }
