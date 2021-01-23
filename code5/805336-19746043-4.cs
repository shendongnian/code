    using (MemoryStream m = new MemoryStream())
    {
        using (BinaryWriter writer = new BinaryWriter(m, Encoding.UTF8, true))
        {
            writer.Write((int)this.Opcode);
            writer.Write(this.Data);
        }
        // m is no longer disposed here
        return m.ToArray();
    }
