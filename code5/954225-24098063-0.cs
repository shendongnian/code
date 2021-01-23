    public static class ReaderExtensions
    {
        public static bool IsDBNull(this SqlDataReader reader, string colName)
        {
            int colPos = reader.GetOrdinal(colName);
             return reader.IsDBNull(colPos);
        }
    }
