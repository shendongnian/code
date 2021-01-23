    private static void Main()
    {            
        var codes = new List<string>() { "qc", "aq", "nc", "ac", "1a", "3c", "-n" };
        codes.Sort(CodeComparer);
        Console.WriteLine(string.Join(", ", codes));
    }
