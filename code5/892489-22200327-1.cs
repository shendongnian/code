    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < rest.Length; i++)
    {
        char c = rest[i];                       
        bool takeChar = !Char.IsLetter(c) && !Char.IsWhiteSpace(c);
        if (takeChar)
            sb.Append(c);
        else
            break;
    }
    result = result + sb.ToString();
