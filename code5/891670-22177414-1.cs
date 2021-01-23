    for(...)
    {
        StringBuilder sb = new StringBuilder(line);
        if (line.Contains("Start **** Connect Process"))
            sb.Append("," + Environment.NewLine + "*****" + Environment.NewLine);
        // do that for each of your conditionals.
        // and finally, add the line to the output buffer:
        outFileContents.Add(sb.ToString());
    }
