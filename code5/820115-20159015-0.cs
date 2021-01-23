    new int[] { 1, 2, 3, 4 }
        .AsParallel()
        .SelectMany(i => {
            if (i % 2 == 0)
                return Enumerable.Repeat(new { i, squared = i * i }, i);
            else
                return Enumerable.Empty<dynamic>();
            })
        .ToList();
