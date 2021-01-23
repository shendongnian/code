    // read all lines from file
    string[] lines = File.ReadAllLines(fileName);
    // Create lists for first and second column
    List<string> cols1 = new List<string>();
    List<string> cols2 = new List<string>();
    // Fill lists. This assumes there's always at least two columns in each row,
    // separated by ","!
    foreach (string line in lines)
    {
        string[] parts = line.Split(',');
        cols1.Add(parts[0]);
        cold2.Add(parts[1]);
    }
    // Create arrays from lists
    string[] colArray1 = cols1.ToArray();
    string[] colArray2 = cols2.ToArray();
