    public static string StringFormat(this string input, Dictionary<string, object> elements)
    {
        int i = 0;
        var values = new object[elements.Count];
        foreach (var elem in elements)
        {
            input = Regex.Replace(input, "{" + Regex.Escape(elem.Key) + "(?<format>[^}]+)?}", "{" + i + "${format}}");
            values[i++] = elem.Value;
        }
        return string.Format(input, values);
    }
