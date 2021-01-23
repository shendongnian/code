    var lines = File.ReadLines(BarCodeList.Text).ToList();
    if (!lines.Any())
    {
        return;
    }
    using (var sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"myFile.txt"))
    {
        foreach (var line in lines)
        {
            sw.WriteLine(line);
        }
    }
