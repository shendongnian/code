        var newdic = new Dictionary<string, List<string>>();
        dic1.ToList().ForEach
        (
            pair =>
            {
                newdic.Add(pair.Key, pair.Value.Where(x => x!="ss").ToList());
            }
        );
