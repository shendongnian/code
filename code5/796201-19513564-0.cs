    var regex = new Regex(@"^SENT KV(?<singlelinedata> L(?<singlelinedata>[1-9]\d*) (?<singlelinedata>\d+)(?: (?<singlelinedata>\d+))+)+$");
    var matches = regex.Matches("SENT KV L1 123 1 2 3 L2 456 4 5 6 12 13 L3 789 7 8 9 10");
    var singlelinedata = matches[0].Groups["singlelinedata"];
            
    string groupKey = null;
    var result = singlelinedata.Captures.OfType<Capture>()
        .Reverse()
        .GroupBy(key => groupKey = key.Value.Contains("L") ? key.Value : groupKey, value => value.Value)
        .Reverse()
        .Select(group => new { key = group.Key, data = group.Skip(1).Reverse().ToList() })
        .Select(item => new { line = item.data.First(), measureline = item.data.Skip(1).First(), samplingpoints = item.data.Skip(2).ToList() })
        .ToList();
