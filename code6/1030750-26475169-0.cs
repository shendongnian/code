    StringBuilder sb = new StringBuilder(text.Length);
    bool firstSpace = true;
    char[] dont = { '\n', '\r' };
    for(int i = 0; i < text.Length; i++)
    {
        char c = text[i];
        if (dont.Contains(c)) c = ' ';  // replace new-line characters with a single space
        bool isWhiteSpace = Char.IsWhiteSpace(c) ;
        bool append =  !isWhiteSpace || firstSpace;
        firstSpace = !isWhiteSpace;
        if(append) sb.Append(c);
    }
    string withOneSpaceAndNoLines = sb.ToString();
