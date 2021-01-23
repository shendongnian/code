        string svg;
        using (var stream = new DeflateStream(new MemoryStream(compressed),  
            CompressionMode.Decompress))
        {
            using (MemoryStream memory = new MemoryStream())
            {
                stream.CopyTo(memory);
                byte[] decompressed = memory.GetBuffer();
                svg = Encoding.UTF8.GetString(decompressed);  
            }     
        }
