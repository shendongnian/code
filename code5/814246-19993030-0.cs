    public static class StringSupport
    {
        public static bool IsPalindrome(this string s)
        {
            return s == new string(s.Reverse().ToArray());
        }
    }
