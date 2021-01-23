    string initial = "XXÈ";
    string normal = initial.Normalize(NormalizationForm.FormD);
    var withoutDiacritics = normal.Where(
        c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark);
    string final = new string(withoutDiacritics.ToArray());
    bool equals = "XXE".Equals(final); // true
