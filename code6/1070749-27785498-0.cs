    var lines = File.ReadAllLines(fileName);
    using (var writer = new StreamWriter(fileName))
    {
        foreach (var line in lines)
        {
            writer.WriteLine(line.PadLeft(31, '0'));
        }
    }
