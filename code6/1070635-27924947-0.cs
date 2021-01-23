    public void Read(BinaryReader r)
    {
        if (r == null) throw new ArgumentNullException("r");
        var count= r.ReadInt32();
        intermediateResult = new List<byte>(count);
        for (int i=0;i<count;i++)
        {
            intermediateResult.Add(r.ReadByte());
        }
    }
    public void Write(BinaryWriter w)
    {
        if (w == null) throw new ArgumentNullException("w");
        w.Write(intermediateResult.Count);
        foreach(byte b in intermediateResult)
        {
          w.Write(b);
        }
    }
