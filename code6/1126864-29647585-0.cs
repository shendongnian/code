    int k = s.Length;
    int i= 1;
    while (i < s.Length)
    {
        if ((char.IsDigit(s[i - 1]) && char.IsLetter(s[i])) ||
            (char.IsLetter(s[i-1]) && char.IsDigit(s[i])))
        {
            s = s.Insert(i, ((char)10).ToString());
            i++;
        }
        i++;
    }
