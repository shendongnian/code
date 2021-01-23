    var lines = System.IO.File.ReadAllLines("somefile.csv");
    var acceptedLines = new List<string>();
    foreach (var line in lines)
        if (Matches(line))
            acceptedLines.Add(line);
    System.IO.File.WriteAllLines("output.csv", acceptedLines);
    private bool Matches(string s) {
        // Whatever you want, return true to include the line, false to exclude)
    }
