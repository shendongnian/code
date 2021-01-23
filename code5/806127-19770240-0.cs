    using (StreamReader sr = new StreamReader(@"C:\Users\as\Desktop\file\1.txt"))
    {
        string allLinesAsString = sr.ReadToEnd();
        string[] lines = allLinesAsString.Split('\n');
        string[][] allLines = lines.Select(line => line.Trim().Split(' ')).ToArray();
        var rotatedLines = allLines.Transpose().ToList();
        string rotatedLinesAsString = string.Join(Environment.NewLine,
                                    rotatedLines.Select(x => string.Join(" ", x)));
        // write rotatedLinesAsString to a file
    }
