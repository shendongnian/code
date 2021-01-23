    private static IEnumerable<char> ReadCharacters(IEnumerable<string> lines)
    {
        foreach (string line in lines)
        {
            foreach (char c in line + Environment.NewLine)
            {
                yield return c;
            }
         }
    }
