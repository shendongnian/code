    var list = new List<string>
            {
                "send 1",
                "wait 200",
                "loop 5 {",
                "send 2",
                "wait 200",
                "}",
                "send 3",
                "loop 2 {",
                "send a",
                "wait 50",
                "}"
            };
    var indexes = list.Select((x, index) =>
            {
                if (x.Contains('{') || x.Contains('}')) return index;
                return -1;
            }).Where(x => x != -1).ToList();
    var ranges = new Dictionary<int, int>();
    for (int i = 0; i < indexes.Count; i += 2)
    {
          ranges.Add(indexes[i],indexes[i+1]);
    }
    var resultList = list.Where((item, index) => 
                                ranges.Any(r => index > r.Key && index < r.Value))
                         .ToList();
