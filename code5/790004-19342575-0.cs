    public static void Main()
    {
        var fileNames = new List<string>{"test_1.bmp", "test_11.bmp", "test_2.bmp"};
       var sorted=fileNames.ToDictionary(GetIntValueFromString,v=>v).OrderBy(entry=>entry.Key);
        foreach (var keyValuePair in sorted)
        {
            Console.WriteLine(keyValuePair.Value);
        }
        Console.Read();
    }
    static int GetIntValueFromString(string input)
    {
        var result = 0;
        var intString = Regex.Replace(input, "[^0-9]+", string.Empty);
        Int32.TryParse(intString, out result);
        return result;
    }
