    StringBuilder sb = new StringBuilder()
    for (int x = 0; x < 5; x++)
    {
        StringBuilder lineBuilder = new StringBuilder();
        for (int y = 0; y < 18; y++)
        {
            if (lineBuilder.Count > 0)
                lineBuilder.Append(delimiter);
            lineBuilder.Append(output[x,y]);
        }
        sb.AppendLine(lineBuilder);
    }
    File.AppendAllText(filePath, sb.ToString());
