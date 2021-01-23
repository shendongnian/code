    StringBuilder sb = new StringBuilder();
    bool isSpaceFound = false;
    foreach (char c in x)
    {
        if (c == ' ')
        {
            if (!isSpaceFound)
                sb.Append(c);
            isSpaceFound = true;
        }
        else
        {
            isSpaceFound = false;
            sb.Append(c);
        }
    }
    var y = sb.ToString();
