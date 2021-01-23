    public string BLoop()
    {
        var song = new System.Text.StringBuilder();
        for (int i = 99; i > 0; i--)
        {
            song.AppendLine(string.Format("{0} bottles of beer on the wall, {0} bottles of beer.", i));
            song.AppendLine(string.Format("Take one down, pass it around, {1} bottles of beer on the wall.", i, i - 1));
            song.AppendLine();
        }
        return song.ToString();
    }
