    public static bool HasUpperLowerDigit(string text)
    {
        bool hasUpper = false; bool hasLower = false; bool hasDigit = false;
        for (int i = 0; i < text.Length && !(hasUpper && hasLower && hasDigit); i++)
        {
            char c = text[i];
            if (!hasUpper) hasUpper = char.IsUpper(c);
            if (!hasLower) hasLower = char.IsLower(c);
            if (!hasDigit) hasDigit = char.IsDigit(c);
        }
        return hasUpper && hasLower && hasDigit;
    }
