    StringBuilder builder=new StringBuilder(s);
    int offset=0;
    for (int i = 1; i < s.Length; i++)
    {
        if (char.IsDigit(s[i - 1]) && char.IsLetter(s[i]))
        {
            builder.Insert(i+offset, Environment.NewLine);
            //every time you add a line break you need to increment the offset
            offset+=Environment.NewLine.Length;
        }
    }
    s=builder.ToString();
