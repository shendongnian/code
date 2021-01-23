    var lines = File.ReadAllLines(path);
    // need to check how many lines returned before reaching here
    var header = lines.First(); // if there is no header exception will be thrown
    var count = header.Count(x => x == ',') + 1;
    var data = lines
        .Skip(1)
        .Select(x => x
            .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
            .Take(count)
            .ToArray())
        .ToArray();
