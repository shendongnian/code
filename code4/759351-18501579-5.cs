    string result = String.Empty;
    string s = String.Format("{0:D4},{1:D4}", nx, ny);
    string[] values = s.Split(',');
    int counter = 0;
    foreach (string val in values)
    {
        StringBuilder sb = new StringBuilder();
        int digitsCount = 0;
        // Loop through each character in string and only keep digits or minus sign
        foreach (char theChar in val)
        {
            if (theChar == '-')
            {
                sb.Append(theChar);
            }
            if (Char.IsDigit(theChar))
            {
                sb.Append(theChar);
                digitsCount += 1;
            }
            if (digitsCount == 2)
            {
                break;
            }
        }
        result += sb.ToString();
        if (counter < values.Length - 1)
        {
            result += ",";
        }
        counter += 1;
    }
