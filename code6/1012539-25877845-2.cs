    var items = new List<HashSet<string>>
    {
        new HashSet<string> {"1", "2"},
        new HashSet<string> {"2", "3"},
        new HashSet<string> {"3", "4"},
        new HashSet<string>{"1", "4"}
    };
    var intersects = items.AsParallel()
        .Select(item => items.AsParallel().Select(item2 =>
            item.Intersect(item2).Count()).ToList()).ToList();
