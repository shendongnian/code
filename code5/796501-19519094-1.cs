    public static class Extensions
    {
        public static bool GetBoolean(this IDataReader reader, string name)
        {
             return reader.GetBoolean(reader.GetOrdinal(name));
        }
    
        public static int GetInt32(this IDataReader reader, string name)
        {
             return reader.GetInt32(reader.GetOrdinal(name));
        }
    }
