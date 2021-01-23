    var filePath = @"C:\test.txt";
    var newFileText = new StringBuilder();
    foreach (var line in File.ReadAllLines(filePath))
    {
        var newLine = new StringBuilder(line);
        newLine.Insert(0, "0");
        newLine.Insert(1, "0");
        newLine.Remove(11, 14);
        newLine.Insert(11, "R");
        newLine.Insert(12, "M");
        newLine.Insert(13, "A");
        newLine.Insert(14, "L");
        newLine.Insert(15, "L");
        newLine.Insert(16, " ");
        newLine.Insert(17, " ");
        newLine.Insert(18, " ");
        newLine.Insert(28, DateTime.Today.ToString("s"));
        newLine.Append("CL");
        newFileText.AppendLine(newLine.ToString());
    }
    File.WriteAllText(filePath, newFileText.ToString());
