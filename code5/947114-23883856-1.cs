    int[] intx = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    var twoDigitsSumEquals10 = intx
        .SelectMany((i1, index) =>
            intx.Skip(index + 1)
                .Select(i2 => Tuple.Create(i1, i2)))
        .Where(t => t.Item1 + t.Item2 == 10);
