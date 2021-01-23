    static public bool DoubleConverter(char c, string str)
    {
        if (!char.IsDigit(c))
        {
            if (c == '.' && (str.Contains('.')))
            {
                return true;
            }
            else if (c != '.')
            {
                return true;
            }
        }
        return false;
    }
