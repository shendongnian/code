    var lines = File.ReadLines(BarCodeList.Text).ToList();
    if (!lines.Any())
    {
        return;
    }
    var dir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\" +
                DateTime.UtcNow.ToString("yyyyMMdd");
    Directory.CreateDirectory(dir);
    File.WriteAllLines(dir + @"\myFile.txt", lines);
