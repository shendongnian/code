    public static byte[] CreateBlock(uint type, uint tag, byte[] data)
    {
        using (var memory = new MemoryStream())
        {
            using (var writer = new BinaryWriter(memory))
            {
                // There is no Endian - things are always little-endian.
                writer.Write((uint)data.Length+16);
                writer.Write((uint)0x00);
                writer.Write(type);
                writer.Write(data);
            }
            return memory.ToArray();
        }
    }
