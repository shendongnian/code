       // Note: Caller must Dispose/Close.
        public DataReader ReadCompressedData()
        {
            // TODO: Optimize when using MemoryStream to use GetBuffer?
            var uncompressedSize = ReadInt32();
            var compressedSize = ReadInt32();
            
            // Consuming 2 bytes for the 78 9C (Sometimes other like 78 DA)
            // Unity / .Net Deflate Stream expects the data to not have this header.
            // I could use the SharpZlib project to get around this or the DotNetZip.
            // https://stackoverflow.com/questions/762614/how-do-you-use-a-deflatestream-on-part-of-a-file
            // http://www.faqs.org/rfcs/rfc1950.html
            // https://stackoverflow.com/questions/20850703/cant-inflate-with-c-sharp-using-deflatestream
            //stream.Position += 2;
            byte[] magic = ReadBytes(2);
            compressedSize -= 2;
            // I wonder if I should check these?
            
            var compressedData = ReadBytes(compressedSize);
            if (compressedData.Length != compressedSize)
            {
                Debug.LogError("Data read from underlying stream does not match specified size.");
            }
            // Decompress the data in the stream leaving it open.
            // Note: Not sure how to stop DeflateStream gobbling up all data in the stream.
            // using (var ds = new DeflateStream(BaseStream, CompressionMode.Decompress, true))
            // {
            //
            // }
            // Note: We are trusting that the decompressed data will fit completely into uncompressedSize.
            var os = new MemoryStream(uncompressedSize);
            using (var inputStream = new MemoryStream(compressedData))
            {
                using (var ds = new DeflateStream(inputStream, CompressionMode.Decompress))
                {
                    ds.CopyTo(os);
                }
            }
            // Reset the stream to the beginning for reading.
            os.Position = 0;
            return new DataReader(os);
        }
