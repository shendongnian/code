    public string BLoop()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 99; i > 0; i--)
        {
            sb.AppendLine(string.Format("{0} bottles of beer on the wall, {0}   bottles of beer.", i));
            sb.AppendLine(string.Format("Take one down, pass it around, {1} bottles of beer on the wall.", i, i - 1));
            sb.AppendLine(Environment.NewLine);
        }
        return sb.ToString();
    }
