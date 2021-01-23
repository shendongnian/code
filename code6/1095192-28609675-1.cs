    public static class DataReaderExtension
    {
         public static string GetStringOrNull(this IDataReader reader, int ordinal)
         {
              var value = null;
              if(!reader.IsDBNull(reader.GetOrdinal(ordinal)
                   reader.GetString(ordinal);
    
              return value;
         }
    
         public static string GetStringOrNull(this IDataReader reader, string columnName)
         {
              return reader.GetStringOrNull(reader.GetOrdinal(columnName));
         }
    }
