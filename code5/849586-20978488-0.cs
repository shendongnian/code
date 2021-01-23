    static class Extensions
    {
        public static int? ParseAsInteger(this string s)
        {
            int j;
            bool success = int.TryParse(s, out j);
            return success ? (int?)j : (int?)null;
        }
    }
