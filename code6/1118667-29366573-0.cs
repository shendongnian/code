        public static bool HasWordsContaining(this string searchCriteria, string toFilter)
        {
            var regex = new Regex(string.Format("^{0}| {0}", Regex.Escape(toFilter)), RegexOptions.IgnoreCase);
            return regex.IsMatch(searchCriteria);
        }
