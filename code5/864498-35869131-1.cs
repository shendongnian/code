    public static class CanTestDbFunctions
    {
        [System.Data.Entity.DbFunction("Edm", "TruncateTime")]
        public static DateTime? TruncateTime(Nullable<DateTime> dateValue)
        {
            ...
        }
    }
