    public static class StringExtensions
    {
        public static string Preceeds(this string s, string word)
        {
            string response = s;
            int pos2 = s.IndexOf(word);
            int pos1 = s.Substring(0, pos2).LastIndexOf(" ");
            if (pos1 != -1 && pos2 != -1 && (pos2 >= pos1))
            {
                response = s.Substring(pos1, pos2 - pos1 + word.Length);
            }
            return response;
        }
    }
