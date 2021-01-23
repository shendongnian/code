    public byte[] ByteArraySerialize()
    {
        using (MemoryStream m = new MemoryStream())
        {
            using (BinaryWriter writer = new BinaryWriter(m))
            {
                writer.Write((int)this.Opcode);
                writer.Write(this.Data);
            }
            // m is really disposed here
            return m.ToArray();
        }
    }
