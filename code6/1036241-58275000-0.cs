    public static List<string> GetDataLinesFromCSV(string csv)
    {
        var csvLines = csv.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        var dataLines = csvLines.AsQueryable().Where((x, idx) => idx > 0).ToList();
        return dataLines;
    }
