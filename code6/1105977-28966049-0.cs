    byte[] BuildDatagram(int playerId, int x, int y)
    {
        using (MemoryStream stream = new MemoryStream)
        using (BinaryWriter writer = new BinaryWriter(stream))
        {
            writer.Write(playerId);
            writer.Write(x);
            writer.Write(y);
            writer.Flush();
            return stream.ToArray();
        }
    }
