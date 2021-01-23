    public static bool HasIdenticalSubStrings(string str, int len)
    {
        bool returnValue = false;
        List<String> lst = new List<string>();
        for (int i = 0; i <= str.Length - len; i++)
            lst.Add(str.Substring(i, len));
        returnValue = (lst.Distinct().Count() != lst.Count);
        return returnValue;
    }
