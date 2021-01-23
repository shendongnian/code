    public static IEnumerable<string> SplitLazy(this string str, params char[] separators)
    {
        List<char> temp = new List<char>();
        foreach (var c in str)
        {
            if (separators.Contains(c) && temp.Any())
            {
                 yield return new string(temp.ToArray());
                 temp.Clear();
            }
            else
            {
                temp.Add(c);
            }
        }
        if(temp.Any()) { yield return new string(temp.ToArray()); }
    }
