    string src = @"[olist]
        [#]This is line 1
        [#]This is line 2
            [olist]
                [#]This is line 2.1
                    [olist]
                        [#]This is line 2.1.1
                        [#]This is line 2.1.2
                    [/olist]
                [#]This is line 2.2
                [#]This is line 2.3
            [/olist]
        [#]This is line 3
    [/olist]";
    var sb = new StringBuilder();
    var lines = src.Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
    int i = 0;
    int innerListsCount = 0;
    while (i < lines.Length)
    {
        string line = lines[i];
        if (line.EndsWith("[olist]"))
            sb.AppendLine(line.Replace("[olist]", "<ol>"));
        else if (line.EndsWith("[/olist]"))
        {
            sb.AppendLine(line.Replace("[/olist]", "</ol>"));
            if (innerListsCount > 0)
            {
                for (int j = 0; j <= innerListsCount; j++)
                    sb.Append("    ");
                sb.AppendLine("</li>");
            }
            innerListsCount--;
        }
        else if (line.Trim().StartsWith("[#]"))
        {
            sb.Append(line.Replace("[#]", "<li>"));
            if (i < lines.Length && lines[i + 1].EndsWith("[olist]"))
            {
                innerListsCount++;
                sb.AppendLine();
            }
            else
                sb.AppendLine("</li>");
        }
        i++;
    }
    Console.WriteLine(sb.ToString());
