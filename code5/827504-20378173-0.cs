    public static class Hex
    {
        static Hex()
        {
            _HexNameCounts = new Dictionary<string, int>() 
            {
                {"aba", 0}, {"bcd", 0}, {"c", 0}
            };
        }
        private static Dictionary<string, int> _HexNameCounts = null;
        public static int? GetHexNameCount(string name)
        {
            int count;
            if (_HexNameCounts.TryGetValue(name, out count))
                return count;
            return null;
        }
        public static void SetHexNameCount(string name, int count)
        {
            _HexNameCounts[name] = count;
        }
    }
