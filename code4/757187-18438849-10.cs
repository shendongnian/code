    public static class DataExtensions
    {
        public static string GetSafeString(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader[colIndex].ToString();
            else
                return string.Empty;
        }
    }
