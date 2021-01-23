    string[] b = new string[a.Length];
    var duplicatedItems = a.GroupBy(a => a)
                           .Where(g => g.Count() > 0)
                           .ToDictionary(g => g.Key, g => g.Count());
    for(int i = b.Length - 1; i >= 0 ; i--)
    {
        string item = a[i];
        if (!duplicatedItems.ContainsKey(item))
        {
            b[i] = item;
            continue;
        }
      
        b[i] = String.Format("{0}_{1}", item, duplicatedItems[item]);
        duplicatedItems[item]--;       
    }
