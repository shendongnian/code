    TextInfo tCase = new CultureInfo("en-US", false).TextInfo;
    string s = "dr. david BOWIE md";
    var array = s.Split(' ');
    List<string> newList = new List<string>(array.Length);
    foreach (string v in array)
    {
        if (v.Length == 2)
        {
            newList.Add(v.ToUpper());
        }
        else
        {
            newList.Add(tCase.ToTitleCase(v.ToLower()));
        }
    }
    Console.WriteLine(string.Join(" ", newList));
