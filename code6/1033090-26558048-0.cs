    var dict = new Dictionary<string, string>();
                dict.Add("test", "blah");
                dict.Add("tesT", "meh");
    
                dict[dict.Keys.Where(k => k.Equals("test", StringComparison.OrdinalIgnoreCase)).First()] = "this";
