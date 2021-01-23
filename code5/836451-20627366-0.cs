    var hm1 = new HashSet<int>(new[] {1, 2, 3, 4, 5});
    var hm2 = new HashSet<int>(new[] { 2, 4, 6, 7, 8 });
    var hm3 = new HashSet<int>(new[] { 3, 4, 5, 6, 9 });
    var intersection = hm1.Intersect(hm2).Intersect(hm3);
    foreach (var i in intersection)
    {
        Console.WriteLine(i);
    }
