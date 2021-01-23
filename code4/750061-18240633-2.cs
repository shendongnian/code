    string RemoverAcentuacao(string s)
    {
        return String.Join("",
                s.Normalize(NormalizationForm.FormD)
                .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark));
    }
