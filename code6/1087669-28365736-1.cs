    public static IEnumerable<string> SplitIntoLines(this string text)
    {
        using (var reader = new StringReader(text))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
