    string RemoverAcentuacao(string s)
    {
        return String.Join("",
                s.Normalize(NormalizationForm.FormD)
                .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .Select(c=> char.IsLetterOrDigit(c) ? c : '_')
                .Select(c => (int)c < 128 ? c : '_'));
    }
