    string dir = @"C:\DirectoryName";
    string[] files = Directory.GetFiles(dir, "*.csv", SearchOption.TopDirectoryOnly);
    var dateFiles = new Dictionary<DateTime, List<string>>();
    foreach (string file in files)
    {
        string fn = Path.GetFileNameWithoutExtension(file);
        if (fn.Length < "YYYYMMDD_HHmmss".Length)
            continue;
        string datePart = fn.Substring(0, "YYYYMMDD_HHmmss".Length);
        DateTime dt;
        if(DateTime.TryParseExact(datePart, "YYYYMMDD_HHmmss", DateTimeFormatInfo.CurrentInfo, DateTimeStyles.None, out dt))
        {
            bool containsDate = dateFiles.ContainsKey(dt.Date);
            if(!containsDate) dateFiles.Add(dt.Date, new List<string>());
            dateFiles[dt.Date].Add(file);
        }
    }
    foreach(KeyValuePair<DateTime, List<string>> dateFile in dateFiles)
        MergeFilesForDay(dir, dateFile.Key, dateFile.Value);
