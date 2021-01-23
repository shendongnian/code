    public static bool isPalindrome(string _text)
    {
        var halfLen = (int)Math.Ceiling(_text.Length / 2.0);
        return _text.Take(halfLen).SequenceEqual(_text.Reverse().Take(halfLen));
    }
