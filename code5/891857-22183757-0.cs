    var input = "March 03 2014 abcd March 03 2014 def March 03 2014 abcd March 04 2014 xyz March 04 2014 xyz";
    var format = "MMMM dd yyyy";
    var results = input.Split(' ')
                       .Select((v, i) => new { v, i })
                       .GroupBy(x => x.i / 4, x => x.v, (k, g) => g.ToList())
                       .Select(g => new
                       {
                           Date = DateTime.ParseExact(String.Join(" ", g.Take(3)), format, CultureInfo.InvariantCulture),
                           Event = g[3]
                       })
                       .GroupBy(x => x)
                       .Where(g => g.Count() > 1)
                       .Select(g => new
                       {
                           Item = g.Key,
                           Count = g.Count()
                       });
    foreach (var i in results)
        Console.WriteLine("{0} {1} {2}", i.Item.Date.ToString(format), i.Item.Event, i.Count.ToString());
