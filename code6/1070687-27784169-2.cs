    var zip = s2.Select(s => Tuple.Create(1, s))
        .Merge(s3.Select(s => Tuple.Create(2, s)))
        .Zip(s1, Tuple.Create);
    var zip1 = zip.Where(pair => pair.Item1.Item1 == 1)
        .Select(pair => Tuple.Create(pair.Item2, pair.Item1.Item2));
    var zip2 = zip.Where(pair => pair.Item1.Item1 == 2)
        .Select(pair => Tuple.Create(pair.Item2, pair.Item1.Item2));
