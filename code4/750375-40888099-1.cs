    public static class DataReaderExtensions
    {
        /// <summary>
        /// writes the content of the field into a stream
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="ordinal"></param>
        /// <param name="stream"></param>
        /// <returns>number of written bytes</returns>
        public static long WriteToStream(this IDataReader reader, int ordinal, Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            if (reader.IsDBNull(ordinal))
                return 0;
            long num = 0L;
            byte[] array = new byte[8192];
            long bytes;
            do
            {
                bytes = reader.GetBytes(ordinal, num, array, 0, array.Length);
                stream.Write(array, 0, (int)bytes);
                num += bytes;
            }
            while (bytes > 0L);
            return num;
        }
        /// <summary>
        /// writes the content of the field into a stream
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="field"></param>
        /// <param name="stream"></param>
        /// <returns>number of written bytes</returns>
        public static long WriteToStream(this IDataReader reader, string field, Stream stream)
        {
            int ordinal = reader.GetOrdinal(field);
            return WriteToStream(reader, ordinal, stream);
        }
    }
