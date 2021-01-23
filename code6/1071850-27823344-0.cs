            var databaseResult = "<xml>Very Long Xml String</xml>";
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(databaseResult);
                    writer.Flush();
                    stream.Position = 0;
                    using (var outFile = File.Create(@"c:\temp\output.xml.gz"))
                    using (var Compress = new System.IO.Compression.GZipStream(outFile, CompressionMode.Compress))
                    {
                        var buffer = new byte[65536];
                        int numRead;
                        while ((numRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            Compress.Write(buffer, 0, numRead);
                        }
                    }
                }
            }
