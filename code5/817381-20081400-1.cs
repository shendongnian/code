    var s = new List<int>(){1, 4, 6, 8};
    var tt = s.Aggregate(new List<int>(), (a, b) => {
                 if (a.Count % 2 != 0)
                 {
                     a.Add(b - a[a.Count - 1]);
                 }
                 a.Add(b);
                 return a; 
             });
