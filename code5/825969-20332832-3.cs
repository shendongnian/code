    /// <summary>
    /// </summary>
    /// <param name="eng">English word before being translated to Pig Latin.</param>
    /// <param name="suffixWithNoOnset">Used to differentiate between Pig Latin dialects.
    /// Known dialects may use any of: "ay", "-ay", "way", "-way", "yay", or "-yay".
    /// Cooresponding translations for 'egg' will yield: "eggay", "egg-ay", "eggway", "egg-way", "eggyay", "egg-yay".
    /// Or for 'I': "Iay", "I-ay", "Iway", "I-way", "Iyay", "I-yay".
    /// </param>
    /// <returns></returns>
    public static string PigLatinizeWord(string eng, string suffixWithNoOnset = "-ay")
    {
        if (eng == null || eng.Length == 0) { return eng; } // don't break if null or empty
        string[] onsetAndEnd = GetOnsetAndEndOfWord(eng);
        // string h = string.Empty;
        string o = onsetAndEnd[0]; // 'Onset' of first syllable that gets moved to end of word
        string e = onsetAndEnd[1]; // 'End' of word, without the onset
        bool hyphenate = suffixWithNoOnset.Contains('-');
        // if (hyphenate) { h = "-"; }
        var sb = new StringBuilder();
        if (e.Length > 0) { sb.Append(e); if (hyphenate && o.Length > 0) { sb.Append('-'); } }
        if (o.Length > 0) { sb.Append(o); if (hyphenate) { sb.Append('-'); } sb.Append("ay"); }
        else { sb.Append(suffixWithNoOnset); }
        return sb.ToString();
    } // public static string PigLatinizeWord(string eng)
    public static string[] GetOnsetAndEndOfWord(string word)
    {
        if (word == null) { return null; }
        // string[] r = ",".Split(',');
        string uppr = word.ToUpperInvariant();
        if (uppr.StartsWith("QU")) { return new string[] { word.Substring(0,2), word.Substring(2) }; }
        int x = 0; if (word.Length <= x) { return new string[] { string.Empty, string.Empty }; }
        if ("AOEUI".Contains(uppr[x])) // tests first letter/character
        { return new string[] { word.Substring(0, x), word.Substring(x) }; }
        while (++x < word.Length)
        {
            if ("AOEUIY".Contains(uppr[x])) // tests each character after first letter/character
            { return new string[] { word.Substring(0, x), word.Substring(x) }; }
        }
        return new string[] { string.Empty, word };
    } // public static string[] GetOnsetAndEndOfWord(string word)
