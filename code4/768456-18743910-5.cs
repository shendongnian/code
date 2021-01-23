    count = reader.ReadInt32();
    byte[] guidBytes = new byte[16];
    for (int i = 0; i < count; ++i)
    {
        string s = reader.ReadString();
        reader.Read(guidBytes, 0, guidBytes.Length);
        pairs.Add(new Pair(s, new Guid(guidBytes));
    }
