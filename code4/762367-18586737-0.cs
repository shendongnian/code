    var groups = list.Select(str => str.Split(new[]{"-----"}, StringSplitOptions.None))
        .Select(split => new { Name = split.First(), Value = split.Last() })
        .GroupBy(x => x.Name);
    foreach (var x in groups)
    {
        Console.WriteLine("Name:{0} Values:{1}", x.Key, string.Join(",", x));
    }
