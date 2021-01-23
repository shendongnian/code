    static class Extensions
    {
        public static int? TryParseAsInteger(this string s)
        {
            int j;
            bool success = int.TryParse(s, out j);
            if (success)
                return j;
            else
                return null;
        }
    }
