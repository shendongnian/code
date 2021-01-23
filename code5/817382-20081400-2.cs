    var s = new List<int>(){1, 4, 6, 8};
    var tt = s.Aggregate(new List<int>(), (a, b) => {
                 var c = new List<int>(a);
                 if (c.Count % 2 != 0)
                 {
                     c.Add(b - c[c.Count - 1]);
                 }
                 c.Add(b);
                 return c; 
             });
