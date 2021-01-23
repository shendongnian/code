    /// <summary>
    /// Returns true if the string is null, empty, or a palindrome.
    /// </summary>
    public static bool IsPalindrome(string value)
    {
        if ( string.IsNullOrEmpty(value) )
            return true;
        return isPalindrome(value, 0, value.Length - 1);
    }
    private static bool isPalindrome(string value, int startChar, int endChar)
    {
        if ( value[startChar] != value[endChar] )
            return false;
        if ( startChar >= endChar )
            return true;
        return isPalindrome(value, startChar + 1, endChar - 1);
    }
