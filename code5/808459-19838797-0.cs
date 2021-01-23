    public static string NormalizeDiacritics(this string input)
    {
        if (String.IsNullOrEmpty(input)) return String.Empty;
    
        var sb = new StringBuilder();
        foreach (var c in input.Normalize(NormalizationForm.FormD))
        {
            if (char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                sb.Append(c);
        }
    
        return sb.ToString();
    }
