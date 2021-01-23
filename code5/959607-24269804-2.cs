    foreach (var b in fileBytes)
    {
        string s;
        if (Conversions.TryGetValue(b, out s))
        {
            sb.Append(s);
        }
        else
        {
            sb.Append((char)b);
        }
    }
