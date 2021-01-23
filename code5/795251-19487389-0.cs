    int[] a = {120, 60, 50, 40, 30, 20};
    int[] b = {12, 29, 37, 85, 63, 11};
    int[] c = {30, 23, 90 ,110, 21, 34};
    var ordered = a.Select((item, index) =>
                           Tuple.Create(item, b[index], c[index]))
                   .OrderBy(tuple => tuple.Item1).ToArray();
    a = ordered.Select(tuple => tuple.Item1).ToArray();
    b = ordered.Select(tuple => tuple.Item2).ToArray();
    c = ordered.Select(tuple => tuple.Item3).ToArray();
