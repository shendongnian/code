    public string InsertLines(string Test)
    {
        var builder = new StringBuilder();
        var lines = Test.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        for (var i = 0; i < lines.Length; ++i)
        {
            if (i != 0 && i % 2 == 0)
                builder.AppendLine();
            builder.AppendLine(lines[i]);
        }
        return builder.ToString();
     }
