    string input = "26291,0.04760144554139385,18087,0.1990775029361712,41972,2.208226792687473, 26291,18087,41972,";
    var d = new Dictionary<string, string>();
    var split = input.Split(new char[] {','});
    if (split.Count(x => x == ",") % 2 == 0)
    {
        throw new ArgumentException("Input is not key value pair.");
    }
 
    int i = 0;
    while (i <= split.Length)
    {
        try
        {
            d.Add(split[i], split[i + 1]);
 
            ParseToDouble(numbers, split, i);
            i = i + 2;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
    /// <summary>
    /// Attempts to Parse string to double. Adds to dictionary if successful. Does nothing if fails to parse.
    /// </summary>
    /// <param name="numbers">The dictionary of numbers</param>
    /// <param name="split">The raw input</param>
    /// <param name="i">The iterator</param>
    private static void ParseToDouble(Dictionary<double, double> numbers, string[] split, int i)
    {
        double key;
        bool keySuccess = double.TryParse(split[i], out key);
        double value;
        bool valueSuccess = double.TryParse(split[i + 1], out value);
        if (keySuccess && valueSuccess)
        {
            numbers.Add(key, value);
        }
    }
