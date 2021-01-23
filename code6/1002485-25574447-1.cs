    static IEnumerable<string> ReadAllLines()
    {
        string line;
        while ((line = Console.ReadLine()) != string.Empty)
            yield return line;
    }
