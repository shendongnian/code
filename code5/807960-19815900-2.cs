    foreach (var c in myListOfChars)
    {
        try
        {
            if (!lookup[(int)c]) { // do something }
            lookup[(int)c] = true;
        }
        catch (IndexOutOfRangeException e)
        {
            if (!otherCharacters.Contains(c)) { // do something }
            otherCharacters.Add(c);
        }
    }
