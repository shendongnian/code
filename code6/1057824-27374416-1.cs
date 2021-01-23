        private static string SplitWordsByComma(string s)
        {
            var sb = new StringBuilder(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                while (i < s.Length && !char.IsLetter(s[i]))
                {
                    i++;
                }
                while (i < s.Length && char.IsLetter(s[i]))
                {
                    sb.Append(s[i++]);
                }
                sb.Append(',');
            }
            return sb.Remove(sb.Length - 1, 1).ToString();
        }
