    List<string[]> listofArraysofStrings = new List<string[]>();
    foreach (string line in file.Lines)
    {
        string[] parts = line.Split(',');
        listofArraysofStrings.Add(parts);
    }
