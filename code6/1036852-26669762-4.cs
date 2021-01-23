    // read all lines from file
    string[] lines = File.ReadAllLines(fileName);
    // Create lists for first and second column
    List<string> cols1 = new List<string>();
    List<string> cols2 = new List<string>();
    // Fill lists. This throws an exception if there's a line with only one column
    foreach (string line in lines)
    {
        string[] parts = line.Split(',');
        // Make sure that each line really contains at least two columns!
        if (parts.Length < 2)
            throw new ArgumentException(String.Format("The following line contains only one column: '{0}'", line));
        cols1.Add(parts[0]);
        cold2.Add(parts[1]);
    }
    // Create arrays from lists
    string[] colArray1 = cols1.ToArray();
    string[] colArray2 = cols2.ToArray();
