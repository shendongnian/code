    var allValues = new List<KeyValuePair<string,char>>()
    
    allValues.Add(new KeyValuePair("abc2","2"));
    allValues.Add(new KeyValuePair("def3","3"));
    etc, etc
    
    StringBuilder sb = new StringBuilder();
    foreach (var c in text)
    {
        var matched = allValues.FirstOrDefault(kvp=> kvp.Key.Contains(c));
        if(matched != null)
        {
           sb.Append(matched.Value);
        }
        else
        {
           sb.Append(" ");
        }
    }
    
    Console.WriteLine(sb.ToString());
