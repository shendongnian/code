private const DEFAULT_YEAR = 2000;
private int GetYear(System.Data.IDbCommand command) {
   int year = DEFAULT_YEAR;
   using (System.Data.IDataReader reader = command.ExecuteReader()) {
      if (reader.Read()) {
         year = GetIntOrDefault(reader, 0);
      }
   }
   return year;
}
private  int GetIntOrDefault(System.Data.IDataRecord record, int ordinal) {
   if (record.IsDBNull(ordinal)) {
      return DEFAULT_YEAR;
   } else {
      return record.GetInt32(ordinal);
   }
}
