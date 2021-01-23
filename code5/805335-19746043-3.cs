    using (MemoryStream m = new MemoryStream())
    using (BinaryWriter writer = new BinaryWriter(m))
    {
        writer.Write((int)this.Opcode);
        writer.Write(this.Data);
        writer.Flush();
        return m.ToArray();
    }
