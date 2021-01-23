    string result = String.Empty;
    string s = String.Format("{0:D4},{1:D4}", nx, ny);
    string[] values = s.Split(',');
    int counter = 0;
    foreach(string val in values)
    {
        StringBuilder sb = new StringBuilder();
        // Loop through each character in string and only keep digits
        foreach(char c in val)
        {
            if(Char.IsDigit(c))
            {
                sb.Append(c);
            }
        }
        string digitsOnly = sb.ToString();
        if(counter > 0)
        {
            result += ",";
        }
        if(digitsOnly.Length >= 2)
        {
            result += digitsOnly.Substring(0,2);
        }
        else
        {
            result += digitsOnly;
        }
        counter += 1;
    }
