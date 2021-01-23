    public static class Extensions
    {
        public static string RemoveAfterNumber(this string str)
        {
            int ix = str.IndexOfAny("0123456789".ToCharArray());
            if (ix >= 0)
            {
                return str.Substring(0, ix);
            }
            else
            {
                return null;
            }
        }
    }
