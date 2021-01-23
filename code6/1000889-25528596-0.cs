    var dataLines = File.ReadLines(@"C:\Temp\SplitFileTest\BigFile.txt")
        .SkipWhile(l => String.IsNullOrWhiteSpace(l)).Skip(1); //skip header
    var dataIdGroups = dataLines
        .Select(l => new { Line = l.Trim(), Fields = l.Trim().Split('|') })
        .Where(x => x.Fields.Length == 4)
        .Select(x => new
        {
            Name = x.Fields[0],
            ID = x.Fields[1],
            Phone = x.Fields[2],
            Address = x.Fields[3],
            Line = x.Line
        })
        .GroupBy(x => x.ID);
    var allFileLines = new List<List<string>>();
    foreach (var userGroup in dataIdGroups)
    {
        if (userGroup.Count() > 50 || allFileLines.Count == 0 || allFileLines.Last().Count + userGroup.Count() > 50)
            allFileLines.Add(userGroup.Select(x => x.Line).ToList());
        else
            allFileLines.Last().AddRange(userGroup.Select(x => x.Line));
    }
    for(int i = 0; i < allFileLines.Count; i++)
        File.WriteAllLines(
            string.Format(@"C:\Temp\SplitFileTest\UserFile_{0}.txt", i + 1), 
            allFileLines[i]);
