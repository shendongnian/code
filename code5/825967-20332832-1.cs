    public static string PigLatinizePhrase(string eng)
    {
        if (eng == null) { return null; } // don't break if null
        var word = new StringBuilder(); // only current word, built char by char
        var pig = new StringBuilder(); // pig latin text
        char prevChar = '\0';
        foreach (char thisChar in eng)
        {
            if (char.IsLetter(thisChar))
            {
                word.Append(thisChar);
            }
            else
            {
                if (word.Length > 0)
                {
                    pig.Append(PigLatinizeWord(word.ToString()));
                    word = new StringBuilder();
                }
                pig.Append(thisChar);
            }
            prevChar = thisChar;
        }
        if (word.Length > 0) { pig.Append(PigLatinizeWord(word.ToString())); }
        return pig.ToString();
    } // public static string PigLatinizePhrase(string eng)
