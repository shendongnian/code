    // This version will replace whole words (you don't need spaces around each one)
    string ReplaceWords(string input, Dictionary<string, string> replacements)
    {
        return Regex.Replace(
                   input,
                   @"\b(" 
                       + String.Join("|", replacements.Keys.Select(k => Regex.Escape(k)))
                       + @")\b", // pattern
                   m => replacements[m.Value] // replacement
                   );
    }
    // This version will replace capitalized words if the key is all lowercase
    string ReplaceWords(string input, Dictionary<string, string> replacements)
    {
        return Regex.Replace(
                   input,
                   @"\b(" 
                       + String.Join("|", replacements.Keys.Select(k => Regex.Escape(k)))
                       + @")\b", // pattern
                   m => replacements[m.Value], // replacement
                   RegexOptions.IgnoreCase);
    }
    private static string ReplaceWord(string word, Dictionary<string, string> replacements)
    {
        string replacement;
        // see if word is in the dictionary as-is
        if (replacements.TryGetValue(word, out replacement))
            return replacement;
        // see if the all-lowercase version is in the dictionary
        if (replacements.TryGetValue(word.ToLower(), out replacement))
        {
            // if the word is all uppercase, make the replacement all uppercase
            if (word.ToUpper() == word)
                return replacement.ToUpper();
            // if the first letter is uppercase, make the replacement's first letter so
            if (char.IsUpper(word[0]))
                return char.ToUpper(replacement[0]) + replacement.Substring(1);
            // otherwise just return the replacement as-is
            return replacement;
        }
        // no replacement found, so don't replace
        return word;
    }
