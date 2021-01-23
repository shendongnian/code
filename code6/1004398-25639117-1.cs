    public static byte[] CreateBlock(uint type, uint tag, byte[] data)
    {
        using (var memory = new MemoryStream())
        {
            // We want 'BinaryWriter' to leave 'memory' open, so we need to specify false for the third
            // constructor parameter. That means we need to also specify the second parameter, the encoding.
            // The default encoding is UTF8, so we specify that here.
            var defaultEncoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier:false, throwOnInvalidBytes:true);
            using (var writer = new BinaryWriter(memory, defaultEncoding, leaveOpen:true))
            {
                // There is no Endian - things are always little-endian.
                writer.Write((uint)data.Length+16);
                writer.Write((uint)0x00);
                writer.Write(type);
                writer.Write(data);
            }
            // Note that we must close or flush 'writer' before accessing 'memory', otherwise the bytes written
            // to it may not have been transferred to 'memory'.
            return memory.ToArray();
        }
    }
