    public static class StringBuilderExtensions
    {
        public static string LastStringAppended { get; private set; }
        public static StringBuilder AppendRemember(this StringBuilder sb, object obj)
        {
            string s = obj == null ? "" : obj.ToString();
            LastStringAppended = s;
            return sb.Append(s);
        }
    }
