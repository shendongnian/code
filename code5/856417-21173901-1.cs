    StringBuilder builder = new StringBuilder(); 
    builder.Append(text[0] == '"' ? "\\\"" : text.Substring(0, 1));
    for (int i = 1; i < text.Length; i++)
    {
        Char next = text[i];
        Char last = text[i - 1];
        if (next == '"' && last != '\\')
        {
            builder.Append("\\\"");
        }
        else
           builder.Append(next);
    }
    string result = builder.ToString();
