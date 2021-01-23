    using (var file = File.Open(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite))
    {
        using (var writer = new BinaryWriter(file))
        {
           writer.Write(score);
        }
        using (var reader = new BinaryReader(file))
        {
            playerscore = reader.ReadInt32();
         }
    }
