    string str = "valign = \"middle\"";
    string search = "align = \"middle\"";
    int ix;
    while ((ix = str.IndexOf(search, ix)) != -1)
    {
        if (ix == 0 || !char.IsLetterOrDigit(str[ix - 1]))
        {
            break;
        }
        ix++;
    }
    bool success = ix != -1;
