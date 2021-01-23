    var rows = new List<List<string>>();
    foreach(var line in File.ReadAllLines(docPath))
    {
        var columns = line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        rows.Add(columns);
    }
