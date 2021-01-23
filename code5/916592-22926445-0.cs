    var path = @"c:\temp\test.txt";
    var originalLines = File.ReadAllLines(path);
    var updatedLines = new List<string>();
    foreach (var line in originalLines)
    {
        string[] infos = line.Split(',');
        if (infos[0] == "user2")
        {
            // update value
            infos[1] = (int.Parse(infos[1]) + 1).ToString();
        }
        updatedLines.Add(string.Join(",", infos));
    }
    File.WriteAllLines(path, updatedLines);
