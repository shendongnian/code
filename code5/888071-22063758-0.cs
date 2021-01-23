    public string ConvertNumericChars(string input)
    {
        StringBuilder output = new StringBuilder();
        foreach (char ch in input)
        {
            if (char.IsDigit(ch))
            {
                double value = char.GetNumericValue(ch);
                if ((value >= 0) && (value <= 9) && (value == (int)value))
                {
                    output.Append((char)('0'+(int)value));
                    continue;
                }
            }
            output.Append(ch);
        }
        return output.ToString();
    }
