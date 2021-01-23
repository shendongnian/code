    OrderedDictionary d = new OrderedDictionary();
    
    d.Add("01", "First");
    d.Add("02", "Second");
    d.Add("03", "Third");
    d.Add("04", "Fourth");
    d.Add("05", "Fifth");
    
    for(int i = 0; i < d.Count; i++) // Print keys in order
    {
       Console.WriteLine(d[i]);
    }
