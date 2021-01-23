    byte[] result;
            using(FileStream file = //some filestream I created)
            {
                file.Position = 0;
                using (MemoryStream output = new MemoryStream())
                {
                    using (GZipStream zipper = new GZipStream(output, CompressionMode.Compress))
                    {
                        Pump(file, zipper);
                       
                    }
                    result = output.ToArray();
                }
            }
            return result;
