        static void Write(Stream s, Byte[] bytes)
        {
            using (var writer = new BinaryWriter(s))
            {
                writer.Write(bytes);
            }
        }
