        /// <summary>The average file size, used to preallocate the right amount of memory for compression.</summary>
        private const int AverageFileSize = 100000;
        /// <summary>The default size of the buffer used to convert data. WARNING: Must be a multiple of 2!</summary>
        private const int BufferSize = 32768;
        /// <summary>Decompresses a byte array to unsigned shorts.</summary>
        public static ushort[] Decompress_ByteToShort(byte[] zippedData)
        {
            using (var inputStream = new MemoryStream(zippedData))
                return Decompress_File(inputStream);
        }
        /// <summary>Decompresses a file to unsigned shorts.</summary>
        public static ushort[] Decompress_File(string inputFilePath)
        {
            using (var stream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
                return Decompress_File(stream);
        }
        /// <summary>Decompresses a file stream to unsigned shorts.</summary>
        public static ushort[] Decompress_File(Stream zippedData)
        {
            using (var zip = new DeflateStream(zippedData, CompressionMode.Decompress, true))
            {
                // Our temporary buffer.
                var buffer = new byte[BufferSize];
                // Read the number of bytes, written initially as header in the file.
                zip.Read(buffer, 0, sizeof(int));
                var resultLength = BitConverter.ToInt32(buffer, 0);
                // Creates the result array
                var result = new ushort[resultLength];
                // Decompress the file chunk by chunk
                var resultOffset = 0;
                for (; ; )
                {
                    // Read a chunk of data
                    var count = zip.Read(buffer, 0, BufferSize);
                    if (count <= 0)
                        break;
                    // Copy a piece of the decompressed buffer
                    Buffer.BlockCopy(buffer, 0, result, resultOffset, count);
                    // Advance counter
                    resultOffset += count;
                }
                return result;
            }
        }
        /// <summary>Compresses an ushort array to a file array.</summary>
        public static byte[] Compress_ShortToByte(ushort[] plainData)
        {
            using (var outputStream = new MemoryStream(AverageFileSize))
            {
                Compress_File(plainData, outputStream);
                return outputStream.ToArray();
            }
        }
        /// <summary>Compresses an ushort array directly to a file.</summary>
        public static void Compress_File(ushort[] plainData, string outputFilePath)
        {
            using (var stream = new FileStream(outputFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                Compress_File(plainData, stream);
        }
        /// <summary>Compresses an ushort array directly to a file stream.</summary>
        public static void Compress_File(ushort[] plainData, Stream outputStream)
        {
            using (var zip = new DeflateStream(outputStream, CompressionMode.Compress, true))
            {
                // Our temporary buffer.
                var buffer = new byte[BufferSize];
                // Writes the length of the plain data
                zip.Write(BitConverter.GetBytes(plainData.Length), 0, sizeof(int));
                var inputOffset = 0;
                var availableBytes = plainData.Length * sizeof(ushort);
                while (availableBytes > 0)
                {
                    // Compute the amount of bytes to copy.
                    var bytesCount = Math.Min(BufferSize, availableBytes);
                    // Copy a chunk of plain data into the temporary buffer
                    Buffer.BlockCopy(plainData, inputOffset, buffer, 0, bytesCount);
                    // Write the buffer
                    zip.Write(buffer, 0, bytesCount);
                    // Advance counters
                    inputOffset += bytesCount;
                    availableBytes -= bytesCount;
                }
            }
        }
