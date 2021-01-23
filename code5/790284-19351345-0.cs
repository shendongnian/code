    string names;
    string values;
    using (var stream = new StreamReader("path/to/file.csv"))
    {
         var reader = new StringReader(stream);
         names = reader.ReadLine();
         values = reader.ReadLine();
    }
    var pairs = new Dictionary<string, string>(names.Split(','), values.Split(','));
    pairs.Remove("createAppVersion");
    var firstPartOfFile = string.Join(",", result.Keys);
    var secondPartOfFile = string.Join(",", result.Values);
