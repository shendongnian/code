    var s = "abcd defghi abcd defghi".LimitTo(10);
    public static string LimitTo(this string s, int maxLen)
    {
        string toEnd = "...";
            
        if (s.Length > maxLen)
        {
            maxLen -= toEnd.Length;
            while (!char.IsWhiteSpace(s[maxLen])) maxLen--;
            s = s.Substring(0, maxLen) + toEnd;
        }
        return s;
    }
