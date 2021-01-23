    public static List<string> SomeMethod(int numberOfChars)
    {
        IEnumerable<string> results = new List<string> { "" };
        for (int i = 0; i < numberOfChars; ++i)
            results = from s in results
                      from c in Enumerable.Range('a', 26)
                      select s + (char)c;
        return results.ToList();
    }
