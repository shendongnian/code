    static class extensions
    {
        private static bool InSet(this string s, params string[] p )
        {
            return p.Contains(s);
        }
    }
