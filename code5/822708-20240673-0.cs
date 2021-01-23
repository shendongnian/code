    public static List<string> TrimList(this string[] array)
    {
        var list = new List<string>();
        foreach (var s in array)
        {
            list.Add(s.Trim());
        }
        return list;
    }
