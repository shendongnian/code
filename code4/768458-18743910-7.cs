    private Dictionary<string, Guid> ReadGuidFile(string filename)
    {
        using (var fs = File.OpenRead(filename))
        {
            using (var reader = new BinaryReader(fs, Encoding.UTF8))
            {
                // read the count
                int count = reader.ReadInt32();
                // The guids are in a huge byte array sized 16*count
                byte[] guidsBuffer = new byte[16*count];
                reader.Read(guidsBuffer, 0, guidsBuffer.Length);
                // Strings are all concatenated into one
                var bigString = reader.ReadString();
                // Index is an array of int. We can read it as an array of
                // ((count+1) * 4) bytes.
                byte[] indexBuffer = new byte[4*(count+1)];
                reader.Read(indexBuffer, 0, indexBuffer.Length);
                var guids = new Dictionary<string, Guid>(count);
                byte[] guidBytes = new byte[16];
                int startix = 0;
                int endix = 0;
                for (int i = 0; i < count; ++i)
                {
                    endix = BitConverter.ToInt32(indexBuffer, 4*(i+1));
                    string key = bigString.Substring(startix, endix - startix);
                    Buffer.BlockCopy(guidsBuffer, (i*16),
                                        guidBytes, 0, 16);
                    guids.Add(key, new Guid(guidBytes));
                    startix = endix;
                }
                return guids;
            }
        }
    }
