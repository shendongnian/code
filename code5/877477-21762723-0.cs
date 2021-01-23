    private const int kMinimumLength = 8;
    private static string _specialChars = "@#_";
    private static bool IsSpecialChar(char c) { return _specialChars.IndexOf(c) >= 0; }
    private static bool IsValidPasswordChar(char c) { return IsSpecialChar(c) || Char.IsLetterOrDigit(c); }
    public static bool IsPasswordValid(string password)
    {
        if (password == null || password.Length < kMinimumLength || IsSpecial(password[0])
            || IsSpecial(password[password.Length - 1]))
                 return false;
        bool hasLetter = false, hasDigit = false;
        int specials = 0;
        foreach (char c in password)
        {
           hasDigit = hasDigit || Char.IsDigit(c);
           hasLetter = hasLetter || Char.IsLetter(c);
           specials += IsSpecialChar(c) ? 1 : 0;
           if (!IsValidPasswordChar(c)) return false;
        }
        return hasDigit && hasLetter && specials > 1;
    }
