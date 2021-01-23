    public Dictionary<string, List<string>> GetCsvFilesGroupedByDate(string csvDirectory)
    {
        var csvFiles = Directory.GetFiles(csvDirectory, "*.csv");
        var groupedByDate = csvFiles.GroupBy(s => Path.GetFileName(s).Substring(0, 8));
        return groupedByDate.ToDictionary(g => g.Key, g => g.ToList());
    }
