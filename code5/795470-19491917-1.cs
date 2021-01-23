    using (var file = File.Open(filename, FileMode.OpenOrCreate,` FileAccess.ReadWrite))
    {
        using (var writer = new StreamWriter(file))
        {
            writer.WriteLine(score.ToString());
        }
        using (var reader = new StreamReader(file))
        {
            playerscore = int.Parse(reader.ReadLine());
        }
    }
