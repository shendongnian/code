    private static string ConvertToMorse(string input)
    {
        var morse = new StringBuilder();
        foreach (var character in input)
        {
            var upperCaseChar = char.ToUpper(character);
            if (MorseMap.ContainsKey(upperCaseChar))
            {
                morse.Append(MorseMap[upperCaseChar]);
            }
            else
            {
                // If there's no mapping for this character, just add it
                morse.Append(character);
            }
            // Add a space between each morse string.
            morse.Append(' ');
        }
        return morse.ToString().Trim();
    }
    private static string ConvertToAlpha(string morse)
    {
        var alpha = new StringBuilder();
        // Split words on double-spaces so we can add single spaces back where needed
        var morseCodeWords = morse.Split(new[] {"  "}, StringSplitOptions.None);
        foreach (var morseCodeWord in morseCodeWords)
        {
            var morseCodeStrings = morseCodeWord.Split(' ');
            foreach (var morseCodeString in morseCodeStrings)
            {
                if (MorseMap.ContainsValue(morseCodeString))
                {
                    alpha.Append(MorseMap.First(item => item.Value == morseCodeString).Key);
                }
                else
                {
                    // If there's no mapping for the string, just add it
                    alpha.Append(morseCodeString);
                }
            }
            // Add a space between each word
            alpha.Append(' ');
        }
        return alpha.ToString();
    }
