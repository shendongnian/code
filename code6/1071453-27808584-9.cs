    public static class DbDataRecordExtensions
    {
        public static bool GetBoolean(this DbDataRecord rec, string fieldName)
        {
            return rec.GetBoolean(rec.GetOrdinal(fieldName));
        }
    }
