    static void ConsoleWriteLineNoDiacritics(string stIn)
    {
        string stFormD = stIn.Normalize(NormalizationForm.FormD);
        StringBuilder sb = new StringBuilder();
    
        for (int i = 0; i < stFormD.Length; i++)
        {
            UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[i]);
            if (uc != UnicodeCategory.NonSpacingMark)
            {
                sb.Append(stFormD[i]);
            }
        }
    
        Console.WriteLine(sb.ToString());
    }
