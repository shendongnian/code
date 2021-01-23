    string[] values = new string[] { "1", "2", "3", "1.5", "56.5", "8" };
    string[] files = new string[values.Length];
    HashSet<char> lt5 = new HashSet<char> {'0','1','2','3','4'};
    bool haveDecimal;
    bool haveDecimalConfirmed;
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < values.Length; i++)
    {
        sb.Clear();
        haveDecimal = false;
        haveDecimalConfirmed = false;
        foreach(char c in values[i])
        {
            if (haveDecimal)
            {
                if (lt5.Contains(c))
                {
                    files[i] = sb.ToString();
                }
                else
                {
                    files[i] = (Int32.Parse(sb.ToString()) + 1).ToString();
                }
                haveDecimalConfirmed = true;
                break;
            }
            else if (c == '.')
            {
                haveDecimal = true;
                continue;
            }
            if (c == '-') continue;
            sb.Append(c);
        }
        if (!haveDecimalConfirmed) files[i] = sb.ToString();
    }
