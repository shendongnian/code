    public string BLoop()
    {
        var builder = new StringBuilder();
        for (int i = 99; i > 0; i--)
        {
            builder.AppendLine(string.Format("{0} bottles of beer on the wall, {0} bottles of beer.", i));
            builder.AppendLine(string.Format("Take one down, pass it around, {0} bottles of beer on the wall.", i-1));
        }
        return builder.ToString();
    }
