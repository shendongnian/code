    /// <summary>
    /// Returns true if the string is a palindrome (an empty string is a palindrome).
    /// Returns false if the string is null or not a palindrome.
    /// </summary>
    public static bool IsPalindrome(string value)
    {
        if ( value == null )
            return false;
        if ( value.Length == 0 )
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
