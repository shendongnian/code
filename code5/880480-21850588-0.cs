    string input = "26291,0.04760144554139385,18087,0.1990775029361712,41972,2.208226792687473, 26291,18087,41972,";
    var d = new Dictionary<string, string>();
    var split = input.Split(new char[] {','});
    int i = 0;
    while (i <= split.Length)
    {
        try
        {
            d.Add(split[i], split[i + 1]);
            i = i + 2;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
