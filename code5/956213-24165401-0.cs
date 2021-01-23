    class MyComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            var sets = x.ToCharArray().Zip(y.ToCharArray(), 
                      (LeftChar, RightChar) => new { LeftChar, RightChar });
            var charsToCompare = sets.FirstOrDefault(c => c.LeftChar != c.RightChar);
            if (charsToCompare == null)
                return 0;
            var lowers = char.ToLower(charsToCompare.LeftChar).CompareTo(char.ToLower(charsToCompare.RightChar));
            if (lowers == 0)
                return charsToCompare.RightChar.CompareTo(charsToCompare.LeftChar);
            else
                return char.ToUpper(charsToCompare.LeftChar).CompareTo(char.ToUpper(charsToCompare.RightChar));
        }
    }
