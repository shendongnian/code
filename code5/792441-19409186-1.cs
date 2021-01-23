    string fileName = @"C:\...";
    var dict = new Dictionary<string, int[]>();
    using (var fs = new FileStream(fileName, FileMode.Open))
    using (var reader = new StreamReader(fs))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            var values = line.Split(',');
            dict.Add(values[0], values.Skip(1).Select(x => Convert.ToInt32(x)).ToArray());
        }       
    }
