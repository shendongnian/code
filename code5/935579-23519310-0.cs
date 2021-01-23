    public static string QueryString(IDictionary<string, object> dict)
    {
        var list = new List<string>();
        foreach(var item in dict)
        {
            list.Add(item.Key + "=" + item.Value);
        }
        return string.Join("&", list);
    }
