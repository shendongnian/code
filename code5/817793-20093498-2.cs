    var lines = File.ReadLines(BarCodeList.Text).ToList();
    if (!lines.Any())
    {
        return;
    }
    var dir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\" +
                DateTime.UtcNow.ToString("yyyymmdd");
    Directory.CreateDirectory(dir);
    using (var sw = new StreamWriter(dir + @"\myFile.txt"))
    {
        foreach (var line in lines)
        {
            sw.WriteLine(line);
        }
    }
