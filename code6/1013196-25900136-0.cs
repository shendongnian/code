        public static class DataReaderExtensions 
        {
            public static T Read<T>(this SqlDataReader reader, int index, T defaultValue = default(T))
            {
                var value = reader[index];
        
                return (T)((DBNull.Value.Equals(value))
                           ? defaultValue
                           : Convert.ChangeType(value, typeof(T)));
            }
        }
    
