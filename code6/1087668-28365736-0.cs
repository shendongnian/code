    public static IEnumerable<string> ReadLines(this TextReader reader)
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            yield return line;
        }
    }
