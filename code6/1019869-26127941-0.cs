    var lines10kGroups = File.ReadLines(@"C:\Temp\File.txt")
        .Select(l => new { Line = l, Fields = l.Split(',') })
        .Where(x => x.Fields.Length > 1)
        .Select(x => new{ LastToken = x.Fields.Last().Trim().Split('=').Last(), x.Fields, x.Line})
        .Where(x => x.LastToken.All(Char.IsDigit))  // checks if all characters are digits, pre-check for int.Parse
        .Select(x => new { Count = int.Parse(x.LastToken), x.Line, x.Fields })
        .SelectMany(x => Enumerable.Repeat(x.Line, x.Count)) // this repeats count-lines
        .Select((line, index) => new{ line, index })
        .GroupBy(x => x.index / 10000); // integer division trick to group by 10k lines
    string targetDir = @"C:\Temp\TestDirectory";
    Directory.CreateDirectory(targetDir);
    int fileNum = 0;
    foreach (var lineGroup in lines10kGroups)
    { 
        string path = Path.Combine(targetDir, string.Format("File_{0}.txt", ++fileNum));
        while(File.Exists(path))
            path = Path.Combine(targetDir, string.Format("File_{0}.txt", ++fileNum));
        File.WriteAllLines(path, lineGroup.Select(x => x.line));
    }
