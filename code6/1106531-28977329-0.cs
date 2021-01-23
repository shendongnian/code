    public static List<string> AddIfNotEmpty(this List<string> list, params string[] items)
    {
        list.AddRange(items.Where(s => !string.IsNullOrEmpty(s)));
        return list;
    }
