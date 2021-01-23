    public static class Extensions
    {
        public static bool DbBoolNullable(this object o)
        {
            return Convert.IsDBNull(o) ? false : bool.Parse(o.ToString());
        }
    }
