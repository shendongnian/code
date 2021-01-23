    List<string> lines = new List<string>();
    using (var reader = File.OpenText("file.txt"))
    {
        string line;
        while (reader.BaseStream.Position < DataLimit &&
               (line = reader.ReadLine()) != null)
        {
            lines.Add(line);
        }
    }
