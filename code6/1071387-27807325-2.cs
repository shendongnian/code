    var filePath = @"C:\test.txt";
    var newFileText = new StringBuilder();
    foreach (var line in File.ReadAllLines(filePath))
    {
        var newLine = line
            .Insert(0, "0")
            .Insert(1, "0")
            .Remove(11, 14)
            .Insert(11, "R")
            .Insert(12, "M")
            .Insert(13, "A")
            .Insert(14, "L")
            .Insert(15, "L")
            .Insert(16, " ")
            .Insert(17, " ")
            .Insert(18, " ")
            .Insert(28, DateTime.Today.ToString("yyyy-MM-dd"));
        newLine += "CL";
        newFileText.AppendLine(newLine);
    }
    File.WriteAllText(filePath, newFileText.ToString());
