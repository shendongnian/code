    var lines = new List<string>(File.ReadLines("input.csv"));
    foreach (string line in lines)
    {
        if (line.StartsWith("a")) continue;
        // insert code to modify the other lines
    }
    // ... and later
    File.WriteAllLines("output.csv", lines);
