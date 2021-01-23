    public static string ToCsv<T>(string separator, IEnumerable<T> objectlist)
    {
        Type t = typeof(T);
        FieldInfo[] fields = t.GetFields();
        string header = String.Join(separator, fields.Select(f => f.Name).ToArray());
        StringBuilder csvdata = new StringBuilder();
        csvdata.AppendLine(header);
        foreach (var o in objectlist) 
            csvdata.AppendLine(ToCsvFields(separator, fields, o));
        return csvdata.ToString();
    }
