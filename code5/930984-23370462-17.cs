    int CountCharacters(string text)
    {
        HashSet<string> characters = new HashSet<string>();
        string currentCharacter = "";
        for (int i = 0; i < text.Length; ++i)
        {
            if (Char.IsHighSurrogate(text, i))
            {
                // Do not count this, next one will give the full pair
                currentCharacter = text[i].ToString();
                continue;
            }
            else if (Char.IsLowSurrogate(text, i))
            {
                // Our "character" is encoded as previous one plus this one
                currentCharacter += text[i];
            }
            else
                currentCharacter = text[i].ToString();
            if (!characters.Contains(currentCharacter))
                characters.Add(currentCharacter);
        }
        return characters.Count;
    }
