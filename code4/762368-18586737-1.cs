    var groups = list.Select(str => str.Split(new[]{"-----"}, StringSplitOptions.None))
        .Select(split => new { Name = split.First(), Value = split.Last() })
        .GroupBy(x => x.Name);
    foreach (var grp in groups)
    {
        Console.WriteLine("Name:{0} Values:{1}", grp.Key, string.Join(",", grp.Select(x => x.Value)));
    }
