    var listA = new List<string>() { "A", "B", "C", ... }
    var listB = new List<decimal>() { 1m, 2m, 3m, ... }
    double ratio = ((double)listA.Count) / listB.Count;
    var results = 
        from i in Enumerable.Range(0, listB.Count)
        select new { A = listA[(int)Math.Truncate(i * ratio)], B = listB[i] };
