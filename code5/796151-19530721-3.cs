    private static string ESCAPED_SPECIAL_CHARS = Regex.Escape(@"@#$%&*+_()':;?.,![]\-"); 
    public static bool IsValidPassword(string input) {
        // Length requirement?
        if (input.Length < 8) return false;
        // First just check for a digit
        if (!Regex.IsMatch(input, @"\d")) return false;
        // Then check for special character
        if (!Regex.IsMatch(input, "[" + ESCAPED_SPECIAL_CHARS + "]")) return false;
        // Require a letter?
        if (!Regex.IsMatch(input, "[a-zA-Z]")) return false;
        // DON'T allow anything else:
        if (Regex.IsMatch(input, @"[^a-zA-Z\d" + ESCAPED_SPECIAL_CHARS + "]")) return false;
        return true;
    }
