    List<string> words = new List<string>() { "false", "true", "||", "&&", " " };
    public bool ValidateString(string strCondition)
    {
        if(string.IsNullOrWhiteSpace(strCondition)) return true;
        int charIndex = 0;
        while (charIndex < strCondition.Length)
        {
            string wordFound = null;
            foreach (string word in words)
            {
                if (word.Length + charIndex > strCondition.Length) 
                    continue;
                string substring = strCondition.Substring(charIndex, word.Length);
                if (word == substring)
                {
                    wordFound = word;
                    break;
                }
            }
            if (wordFound == null)
                return false;
            else if (charIndex + wordFound.Length == strCondition.Length)
                return true;
            else
                charIndex += wordFound.Length;
        }
        return false;
    }
