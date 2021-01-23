    public void Test()
    {
        string fileName = "oldFileName";
        string newFileName = "newFileName";
        string[] allLines = File.ReadAllLines(fileName);
        string changedLine = "Changed";
        var changedLines = allLines.Select(p => ((Regex.IsMatch(p, "test")) ? changedLine : p));
        File.WriteAllLines(newFileName, changedLines);
    }
