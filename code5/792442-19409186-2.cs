    string fileName = @"C:\...";
    var dict = new Dictionary<string, int[]>();
    foreach (string line in File.ReadLines(fileName))
    {
        var values = line.Split(',');
        dict.Add(values[0], values.Skip(1).Select(x => Convert.ToInt32(x)).ToArray());
    }
