    string comment = "Ðè";
    // Here we split (è) to U+0065 (e) U+0300 (̀)
    string commentNormalized = comment.Normalize(NormalizationForm.FormD);
    // Here we remove all the UnicodeCategory.NonSpacingMark
    // that are the diacritics like U+0300 (̀)
    // and rebuild the string. This line can be speedup a little, but
    // it would be longer to write :-)
    string comment2 = new string(commentNormalized.Where(x => char.GetUnicodeCategory(x) != UnicodeCategory.NonSpacingMark).ToArray());
