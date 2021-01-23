    TextInfo tCase = new CultureInfo("en-US", false).TextInfo;
    string s = "dr. david BOWIE md"; var newList = new List<string>();
    foreach (string v in s.Split(' ')){
       newList.Add(v.Length == 2 ? v.ToUpper() : tCase.ToTitleCase(v.ToLower()));
    }
    Console.WriteLine(string.Join(" ", newList));
