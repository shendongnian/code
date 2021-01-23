    public static class StringBuilderExtensions
    {
        private static Dictionary<StringBuilder, string> _lastStrings =
            new Dictionary<StringBuilder, string>(
                new ObjectReferenceEqualityComparer<StringBuilder>());
        public static string LastAppended(this StringBuilder sb)
        {
            string s;
            _lastStrings.TryGetValue(sb, out s);
            return s; // s is null if not found in the dict.
        }
        
        public static StringBuilder AppendRemember(this StringBuilder sb, object obj)
        {
            string s = obj == null ? "" : obj.ToString();
            _lastStrings[sb] = s;
            return sb.Append(s);
        }
    }
