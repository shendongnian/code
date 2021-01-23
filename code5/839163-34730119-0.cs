    public static object SetSafeDBDate(System.DateTime dtIn)
        {
            if (dtIn == new DateTime(0))
                return System.DBNull.Value;
            else
                return new DateTime(dtIn.Year,dtIn.Month,dtIn.Day,dtIn.Hour,dtIn.Minute,dtIn.Second);
        }
