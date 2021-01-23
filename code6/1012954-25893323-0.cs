    public static bool IsPalindromic(int l)
        {
            IEnumerable<char> forwards = l.ToString().ToCharArray();
            return forwards.SequenceEqual(forwards.Reverse());
        }
        public int LongestPalindrome(List<int> integers)
        {
            int length=0;
            int num;
            foreach (var integer in integers)
            {
                if (integer.ToString().Length > length)
                {
                    num = integer;
                    length = integer.ToString().Length;
                }
            }
            return num;
        }
        public void  MyFunction(string input)
        {
            var numbers = Regex.Split(input, @"\D+").ToList();
            var allPalindromes = (from value in numbers where !string.IsNullOrEmpty(value) select int.Parse(value) into i where IsPalindromic(i) select i).ToList();
            if (allPalindromes.Count>0)
                Console.WriteLine(LongestPalindrome(allPalindromes));
            else
                Console.WriteLine("Any Palindrome number was found");
        }
    
