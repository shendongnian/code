    string[] lines = combindedString.Split(new string[] { "\n", "\r\n" },
                         StringSplitOptions.RemoveEmptyEntries);
    
    var result = new StringBuilder();
    for (int i = 0; i < lines.Length; i++)
    {
        if (i % 2 == 0 && i != 0)	// i != 0 to not get blank line at the beginning
            result.AppendLine();
        result.AppendLine(lines[i].Trim());
    }
    combindedString = result.ToString();
