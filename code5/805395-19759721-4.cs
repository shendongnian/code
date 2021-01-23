    public IEnumerable<string> ToCsv<T>(string separator, IEnumerable<T> objectlist)
    {
        PropertyInfo[] properties = typeof(T).GetProperties();
        yield return "\"" + String.Join(separator, properties.Select(f => f.Name).ToArray()) + "\"";
        foreach (var o in objectlist)
        {
            yield return "\"" + HttpUtility.HtmlDecode(string.Join(separator, properties.Select(f => (f.GetValue(o) ?? "").ToString()).ToArray())) + "\"";
        }
    }
