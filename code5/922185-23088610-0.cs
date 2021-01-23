    List<List<double>> toTotal = new List<List<double>>() {
	new List<double> {1,   2,   3,   4},
	new List<double> {2,   3 ,  1,   6},
	new List<double> {3 ,  4,   5 ,  6}
                                    };
    var res = toTotal.Select(r => r.Select((t, i) => new { Column = i, Value = t }))
                     .SelectMany(r => r)
                     .GroupBy(r => r.Column)
                     .Select(grp => new
                     {
                         Column = grp.Key,
                         Sum = grp.Select(r => r.Value).Sum(),
                     });
    foreach (var item in res)
    {
        Console.WriteLine("Column: {0}, Sum: {1}", item.Column, item.Sum);
    }
                  
