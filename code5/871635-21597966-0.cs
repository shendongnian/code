    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < text.Length; i++)
    {
        bool replace = false;
        char c = text[i];
        if (c == '-')
        {
            if (i < 2 || i > text.Length - 2) replace = true;
            else
            {
                bool leftDigit = text.Substring(i - 2, 2).All(Char.IsDigit);
                bool rightDigit = text.Substring(i + 1, 2).All(Char.IsDigit);
                replace = !leftDigit || !rightDigit;
            }
        }
        if (replace) sb.Append(' ');
        else sb.Append(c);
    }
