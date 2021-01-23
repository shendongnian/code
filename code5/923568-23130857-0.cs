    static IEnumerable<string> Split(string str)
    {
        while (str.Length > 0)
        {
            yield return new string(str.Take(3).ToArray());
            str = new string(str.Skip(3).ToArray());
        }
    }
