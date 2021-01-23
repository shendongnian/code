    static byte[] HashMd5(string text, int value)
    {
        using (MemoryStream stream = new MemoryStream())
        using (BinaryWriter writer = new BinaryWriter(stream))
        using (System.Security.Cryptography.HashAlgorithm hash =
            new System.Security.Cryptography.MD5Cng())
        {
            writer.Write(text);
            writer.Write(value);
            writer.Flush();
            stream.Position = 0;
            return hash.ComputeHash(stream);
        }
    }
