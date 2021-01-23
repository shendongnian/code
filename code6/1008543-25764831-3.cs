    public class ItemsComparer : IComparer<string>
    {
        private string[] keywords;
        private string pattern;
        public ItemsComparer(string keywords)
        {
            this.keywords = keywords.Split();
            this.pattern = keywords.Replace(' ', '|');
        }
        public int Compare(string x, string y)
        {
            var xMatches = Regex.Matches(x, pattern).Count;
            var yMatches = Regex.Matches(y, pattern).Count;
            if (xMatches != yMatches)
                return yMatches.CompareTo(xMatches);
            if (xMatches == keywords.Length || xMatches == 0)
                return 0;
            foreach (var keyword in keywords)
            {
                var result = y.Contains(keyword).CompareTo(x.Contains(keyword));
                if (result == 0)
                    continue;
                return result;
            }
            return 0;
        }
    }
