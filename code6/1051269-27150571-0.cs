    public static bool IsValidDashedString(this String text)
    {
        bool temp = true;
        //retrieve the location of all the dashes
        var indexes =  Enumerable.Range(0, text.Length)
                .Where(i => text[i] == '-')
                .ToList();
        //check if any dashes occur, if they are the 1st character or the last character
        if (indexes.Count() == 0 ||
            indexes.Any(i => i == 0) ||
            indexes.Any(i => i == text.Length-1))
        {
            temp = false;
        }
        else //check if each dash is preceeded and followed by a letter
        {
            foreach (int i in indexes)
            {
                if (!Char.IsLetter(text[i - 1]) || !Char.IsLetter(text[i + 1]))
                {
                    temp = false;
                    break;
                }
            }
        }
        return temp;
    }
