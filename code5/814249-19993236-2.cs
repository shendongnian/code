    private static string FindLongestPalindrome(string s) 
    {
        string largest = "";
    
        //start at i = 0 instead
        //Also needs to be to i < s.Length or fails some tests
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i; j <= s.Length-i; j++)
            {
                string substring = s.Substring(i, j);
                //you also need to check that you're looking at a longer string
                //this really could be optimized anyway, but here it is for simplicity
                if (substring.Length > largest.Length && IsPalindrome(substring))
                {
                    largest = substring;
                }
            }
        }
    
        return largest;
    }
