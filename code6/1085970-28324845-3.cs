    var propInfos = new Dictionary<string, PropertyInfo>();
    et.Members.ForEach(m => propInfos.Add(m.Name, type.GetProperty(m.Name)));
    foreach (var e in dbEntries)
    {
        var propValues = et.Members
            .Select(m => propInfos[m.Name].GetValue(e).ToString())
            .ToArray();
        Console.WriteLine(" {0}", string.Join(", ", propValues));
    }
