    var stuffToWrite = new List<byte[]>()
    {
        Encoding.UTF8.GetBytes("First string"),
        Encoding.UTF8.GetBytes("Second string"),
        Encoding.UTF8.GetBytes("Third data string")
    };
    using (var file = File.Create(filename))
    using (var binaryWriter = new BinaryWriter(file))
    {
        for (int i = 0; i < stuffToWrite.Count; i++)
        {
            binaryWriter.Write(i);
            binaryWriter.Write(stuffToWrite[i].Length);
            binaryWriter.Write(stuffToWrite[i]);
        }
    }
    using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    using (var br = new BinaryReader(fs))
    {
        long bytesRead = 0;
        long readerLen = br.BaseStream.Length;
        do
        {
            int id = br.ReadInt32();
            int len = br.ReadInt32();
            byte[] data = br.ReadBytes(len);
            bytesRead += (sizeof(int) * 2) + data.Length;
            // Process Data
        } while (bytesRead < readerLen);
    }
