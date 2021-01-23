    public static class DbDataRecordExtensions
    {
        public static bool GetBoolean(this DbDataRecord rec, string fieldName)
        {
            return rec.GetBoolean(rec.GetOrdinal(fieldName));
            // Or this one....
            //return !(rec.GetValue(rec.GetOrdinal(fieldName)) == (object)0); 
        }
    }
