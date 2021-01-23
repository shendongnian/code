    enum Where { None, First, Second, Both } // somewhere in your source file
    
    //...
    var val1 = "Have a good calm day calm calm calm";
    var val2 = "Have a very good day, Joe Joe Joe Joe";
    
    var words1 = from m in Regex.Matches(val1, "(\\w+)|(\\S+\\s+\\S+)").Cast<Match>()
                    where m.Success
                    select m.Value.ToLower();
    var words2 = from m in Regex.Matches(val2, "(\\w+)|(\\S+\\s+\\S+)").Cast<Match>()
                    where m.Success
                    select m.Value.ToLower();
    
    var dic = new Dictionary<string, Where>();
    foreach (var s in words1)
    {
        dic[s] = Where.First;
    }
    foreach (var s in words2)
    {
        Where b;
        if (!dic.TryGetValue(s, out b)) b = Where.None;
    
        switch (b)
        {
            case Where.None:
                dic[s] = Where.Second;
                break;
            case Where.First:
                dic[s] = Where.Both;
                break;
        }
    }
    
    foreach (var kv in dic.Where(x => x.Value != Where.Both))
    {
        Console.WriteLine(kv.Key);
    }
