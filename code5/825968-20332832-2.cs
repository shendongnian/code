    /// <summary>
    /// </summary>
    /// <param name="eng">English text, paragraphs, etc.</param>
    /// <param name="suffixWithNoOnset">Used to differentiate between Pig Latin dialects.
    /// Known dialects may use any of: "ay", "-ay", "way", "-way", "yay", or "-yay".
    /// Cooresponding translations for 'egg' will yield: "eggay", "egg-ay", "eggway", "egg-way", "eggyay", "egg-yay".
    /// Or for 'I': "Iay", "I-ay", "Iway", "I-way", "Iyay", "I-yay".
    /// </param>
    /// <returns></returns>
    public static string PigLatinizePhrase(string eng, string suffixWithNoOnset = "-ay")
    {
        if (eng == null) { return null; } // don't break if null
        var word = new StringBuilder(); // only current word, built char by char
        var pig = new StringBuilder(); // pig latin text
        char prevChar = '\0';
        foreach (char thisChar in eng)
        {
            // the "'" test is so "I'll", "can't", and "Ashley's" will work right.
            if (char.IsLetter(thisChar) || thisChar == '\'')
            {
                word.Append(thisChar);
            }
            else
            {
                if (word.Length > 0)
                {
                    pig.Append(PigLatinizeWord(word.ToString(), suffixWithNoOnset));
                    word = new StringBuilder();
                }
                pig.Append(thisChar);
            }
            prevChar = thisChar;
        }
        if (word.Length > 0)
        {
            pig.Append(PigLatinizeWord(word.ToString(), suffixWithNoOnset));
        }
        return pig.ToString();
    } // public static string PigLatinizePhrase(string eng, string suffixWithNoOnset = "-ay")
