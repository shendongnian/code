    string lines = "a|bc|def";
    string[] separatedLines = lines.Split('|');
    string rejoinedLines = string.Join(Environment.NewLine, separatedLines);
    for (int i = 0; i < separatedLines.Length; i++)
    {
        Console.WriteLine("Line {0}: {1}", i + 1, separatedLines[i]);
    }
