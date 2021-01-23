    public string Populate(string text)
    {
        StringBuilder sb = new StringBuilder();
        if(text.Length > 1)
        {
            for (int i = 1; i < text.Length; i++)
            { 
                Char c = text[i];
                if (c == text[i - 1])
                    sb.Append(c);
            }
        }
        return sb.ToString();
    }
