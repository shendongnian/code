    var l = new List<int>
    {
        1, 4, 3, 8, 2, 11, 4, 3, 5, 19, 2, 8,
        11, 13, 14, 12, 12, 12, 12, 12
    };
    var max = l.Select((x, i) => l.Skip(Math.Max(i - 10, 0)).Take(Math.Min(10, i + 1)).Max()).ToList();
    Console.WriteLine(string.Join(",", max));
    //1,4,4,8,8,11,11,11,11,19,19,19,19,19,19,19,19,19,19,19,14,14,14
