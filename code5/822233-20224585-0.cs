    public bool IsNumber(string text)
    {
        Regex reg = new Regex("^[0-9]+$");
        bool onlyNumbers = reg.IsMatch(text);
        return onlyNumbers;
    }
