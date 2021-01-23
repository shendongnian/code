    var stuffToWrite = new List<byte[]>()
    {
        Encoding.UTF8.GetBytes("First string"),
        Encoding.UTF8.GetBytes("Second string"),
        Encoding.UTF8.GetBytes("Third data string")
    };
    long lastPos = 0;
    for (int i = 0; i < stuffToWrite.Count; i++)
    {    
        using (var file = File.Open(filename, FileMode.Append))
        using (var binaryWriter = new BinaryWriter(file))
        {
            binaryWriter.Write(i);
            binaryWriter.Write((stuffToWrite[i].Length));
            binaryWriter.Write(stuffToWrite[i]);
        }
    }
    using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    using (var br = new BinaryReader(fs))
    {       
        br.BaseStream.Seek(0, SeekOrigin.Begin);
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
