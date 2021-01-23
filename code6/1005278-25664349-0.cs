    public int GetNextNumber()
    {
        char nextChar;
        string numberString = string.Empty;
        while (!char.IsWhiteSpace(nextChar = (char)Console.Read())
            numberString += nextChar;
        int result;
        if (!int.TryParse(numberString, out result))
            throw new InvalidCastException("Specified string is not an integral");
        return result;
    }
