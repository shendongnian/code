    int[] newchartValues = new int[] { 1, 2, 3, 4, 5, 6 };
    int[] newdates = new int[] { 11, 11,11,12,12,12 };
    var pairs = Enumerable.Zip(newdates, newchartValues, (x, y) => new { x, y })
		  .GroupBy(z => z.x)
          .Select(g => new { k = g.Key, s = g.Sum(z => z.y) })
		  .ToList();
    var distinctDates = pairs.Select(p => p.k).ToArray();
    var sums = pairs.Select(p => p.s).ToArray();
