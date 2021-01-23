    var result =
        list
        .GroupBy(x => x.PropA, (key, items) => new { Key = key, Items = items })
        .Select(x => x.Items.Select((item, index) =>
        {
            if (index == 0) return item;
            item.PropA = string.Empty;
            item.PropB = string.Empty;
            return item;
        }))
        .SelectMany(x => x)
        .ToList();
