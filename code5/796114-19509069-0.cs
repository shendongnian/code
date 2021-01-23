    string str = "First Second [insideFirst] Third Forth [insideSecond] Fifth";
    MatchCollection matches = Regex.Matches(str,@"\[.*?\]");
    string[] arr = matches.Cast<Match>()
                          .Select(m => m.Groups[0].Value.Trim(new char[]{'[',']'}))
                          .ToArray();
    foreach (string s in arr)
    {
        Console.WriteLine(s);
    }
    string[] arr1 = Regex.Split(str,@"\[.*?\]")
                         .Select(x => x.Trim())
                         .ToArray();
    foreach (string s in arr1)
    {
        Console.WriteLine(s);
    }
