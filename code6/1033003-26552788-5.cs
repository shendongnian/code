    var stuffToWrite = new List<byte[]>()
    {
        new byte[72],
            new byte[72],
            new byte[72],
    };
    for (int i = 0; i < stuffToWrite.Count; i++)
    {
        using (var file = File.Open(filename, FileMode.Append))
        using (var binaryWriter = new BinaryWriter(file))
        {
            binaryWriter.Write(206);
            binaryWriter.Write((stuffToWrite[i].Length));
            binaryWriter.Write(stuffToWrite[i]);
        }
    }
    using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    using (var br = new BinaryReader(fs))
    {
        do
        {
            int id = br.ReadInt32();
            int len = br.ReadInt32();
            byte[] data = br.ReadBytes(len);
            // Process Data
        } while (br.BaseStream.Position < br.BaseStream.Length);
    }
