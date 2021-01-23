    var data = " 0100000000     Coffee\r\n 0110000000     Mocha\r\n 0120000000     Cappuccino\r\n 01210" +
        "00000     Semi skimmed\r\n 0121100000     Starbuckz\r\n 0121200000     Costa\r\n 01220" +
        "00000     Skimmed\r\n 0130000000     Latte";
    var linesByPrefix = 
        (from l in data.Split(new[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
        let pair = l.Split(new[]{' '},StringSplitOptions.RemoveEmptyEntries)
        select new LineData
        {
            OriginalCode = pair[0],
            Title = pair[1],
            Children = new List<LineData>()
        })
        .ToDictionary(l => l.OriginalCode.TrimEnd('0'));
        
    foreach (var line in linesByPrefix)
    {
        var parentCode = line.Key.Substring(0, line.Key.Length - 1);
        LineData parent;
        if(linesByPrefix.TryGetValue(parentCode, out parent))
        {
            line.Value.Parent = parent;
            parent.Children.Add(line.Value);
        }
    }
    var roots = linesByPrefix.Values.Where(l => l.Parent == null);
