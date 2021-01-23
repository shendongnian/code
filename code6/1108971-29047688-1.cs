    string name = "Amélie Benoît Françoise Ågot Annbjørg";
    // We transform letters with diacritics to "pure" letters (é->e, ç ->c...)
    string normalized = name.Normalize(NormalizationForm.FormD);
    var onlyLetters = normalized.Where(x => x >= 'A' && x <= 'Z' || x >= 'a' && x <= 'z');
    // Note that the ø of Annbjørg will be stripped :-(
    string strippedName = new string(onlyLetters.ToArray());
    Console.WriteLine("Calculating for {0}", strippedName);
    int sum = 0;
    foreach (char ch in onlyLetters)
    {
        char ch2 = char.ToUpper(ch);
        // char have a value... 'A' == 65, 'B' == 66 and so on,
        sum += ch2 - 'A' + 1;
    }
    // Done
