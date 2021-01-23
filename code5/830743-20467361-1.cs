    string str = "example(string1,string2,string3) and test(string4)"
    List<string> params = new List<string>();
    MatchCollection collection = Regex.Matches(str, @"\(([^)]*)\)");
    
    for (int i = 0; i < collection.Count; i++)
    {
       params.AddRange(collection[i].Groups[1].Value.Split(',').ToList());
    }
