    if (path1 != null && Directory.Exists(path1))
    {
        var lines = File.ReadAllLines(path1);
        for (var lineIndex = 0; lineIndex < Math.Min(lines.Length, textBoxes.Count); lineIndex++)
        {
            textBoxes[lineIndex].Text = lines[lineIndex];
        }
    }
