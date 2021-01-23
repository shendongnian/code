    public string ExpandCode(string s)
    {
        var builder = new StringBuilder(s);
        var index = Array.FindIndex(s.ToArray(), x => char.IsDigit(x));
        while (builder.Length < 15)
        {
            builder.Insert(index, '0');
        }
        return builder.ToString();
    }
