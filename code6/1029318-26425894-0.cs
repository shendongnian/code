    List<int> listi = new int[] { 1, 2, 3, 4, 5, 6 }.ToList();
    List<DateTime> listd = new DateTime[] { DateTime.Parse("5-10-2014"), DateTime.Parse("6-10-2014"), DateTime.Parse("7-10-2014") }.ToList();
    
    IEnumerable<Tuple<DateTime, int>> result = 
        Enumerable.Range(0, listi.Count)
        .Select(x => new Tuple<DateTime, int>(listd[x / 2], listi[x]));
