    public static class DataExtensions
    {
        public static string SafeGetString<T>(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader[colIndex].ToString();
            else
                return string.Empty;
        }
    }
