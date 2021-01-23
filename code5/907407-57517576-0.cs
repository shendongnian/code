        public static string UrlConvert(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            var sb = new StringBuilder();
            foreach (var ch in s.ToCharArray())
                if (char.IsUpper(ch))
                {
                    if (sb.Length > 0) sb.Append("-");
                    sb.Append(char.ToLower(ch));
                }
                else
                {
                    sb.Append(ch);
                }
            return sb.ToString();
        }
