    string dir = @"C:\DirectoryName";
    string[] files = Directory.GetFiles(dir, "*.csv", SearchOption.TopDirectoryOnly);
    var dateFiles = new Dictionary<DateTime, List<string>>();
    foreach (string file in files)
    {
        string fn = Path.GetFileNameWithoutExtension(file);
        if (fn.Length < "yyyyMMdd_HHmmss".Length)
            continue;
        string datePart = fn.Remove("yyyyMMdd".Length); // we need only date
        DateTime date;
        if (DateTime.TryParseExact(datePart, "yyyyMMdd", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out date))
        {
            bool containsDate = dateFiles.ContainsKey(date);
            if (!containsDate) dateFiles.Add(date, new List<string>());
            dateFiles[date].Add(file);
        }
    }
    foreach(KeyValuePair<DateTime, List<string>> dateFile in dateFiles)
        MergeFilesForDay(dir, dateFile.Key, dateFile.Value);
