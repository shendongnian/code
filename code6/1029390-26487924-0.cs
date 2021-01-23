    public static class DBNullExt
    {
        public static string DBNToString(this object value)
        {
            if (value == System.DBNull.Value)
                return null;
            else
            {
                string val = value.ToString();
                DateTime test;
                string format = "MM/dd/yyyy h:mm:ss tt";
                if (DateTime.TryParseExact(val, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out test))
                    return test.ToShortDateString();
                else
                    return val;
            }
        }
    }
