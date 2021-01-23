        byte[] CompressByteArray(byte[] uncompressedData)
        {
            byte[] compressedData;
            using (MemoryStream ms = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(ms))
                {
                    // dummy compression algorithm
                    for (int i = 0; i < uncompressedData.Length; i += 2)
                    {
                        var newByte = uncompressedData[0] + uncompressedData[1];
                        writer.Write(newByte);
                    }
                }
                ms.Flush();
                ms.Position = 0;
                compressedData = ms.ToArray();
            }
            return compressedData;
        }
