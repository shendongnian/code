    private static List<T> BuildFromCsvFile<T>(string path, string separator = ",")
        where T : new()
    {
        string[] separators = {separator};
        var lines = File.ReadAllLines(path);
        var deserializer = CreateCsvDeserializer<T>(lines[0].Split(separators, StringSplitOptions.RemoveEmptyEntries));
        return
            lines.Skip(1)
                .Select(s => s.Split(separators, StringSplitOptions.RemoveEmptyEntries))
                .Select(deserializer)
                .ToList();
    } 
