    private static string DecompressGzip(Stream input, Encoding e)
        {
            using (Ionic.Zlib.GZipStream decompressor = new Ionic.Zlib.GZipStream(input, Ionic.Zlib.CompressionMode.Decompress))
            {
                int read = 0;
                var buffer = new byte[4096];
                using (MemoryStream output = new MemoryStream())
                {
                    while ((read = decompressor.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        output.Write(buffer, 0, read);
                    }
                    return e.GetString(output.ToArray());
                }
            }
        }
