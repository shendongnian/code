    public static bool ValidateMaximumLength(this string input, int characterCount)
    {
        return input.IsNullOrEmpty() ? true : input.Length <= characterCount;
    }
    public static string GetMaximumLengthError(this string input, int characterCount, 
        bool isInputAdjusted)
    {
        if (isInputAdjusted) return input.GetMaximumLengthError(characterCount);
        string error = "The {0} field requires a value with a maximum of {1} in it.";
        return string.Format(error, input, characterCount.Pluralize("character"));
    }
