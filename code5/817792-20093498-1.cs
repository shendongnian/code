    var lines = File.ReadLines(BarCodeList.Text).ToList();
    if (!lines.Any())
    {
        return;
    }
    var dir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\" +
                DateTime.UtcNow.ToString("yyyymmdd");
    if (!Directory.Exists(dir))
    {
        Directory.CreateDirectory(dir);
    }
    using (var sw = new StreamWriter(dir + @"\myFile.txt"))
    {
        sw.WriteLine("Hello World");
    }
