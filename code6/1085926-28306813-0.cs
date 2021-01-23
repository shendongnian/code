    public static class OptionsNames
    {
        private static Dictionary<int, string> names;
        static OptionsNames()
        {
            names = new Dictionary<int, string>();
            names = LoadOptionsFromXML();
        }
        public static string GetNameById(int id)
        {
            if (names.ContainsKey(id))
                 return names[id];
            return string.Empty;
        }
        // other class members
    }
