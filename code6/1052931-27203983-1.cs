    IQueryable<MyType> query = // get table IQueryable from the Linq2Sql data context
    
    var dateTime = DateTime.Parse("2014-11-27");
    var result = query.Where(t => t.Column2 < dateTime)
        .GroupBy(t => t.Column1)
        // Linq doesn't have HAVING, you can just use Where(). Here, we're operating on
        // an IQueryable of IGrouping, and we're filtering based on taking sums over the groups
        .Where(g => g.Sum(t => !t.Column3 ? 1 : 0) > g.Sum(t => t.Column3 ? 1 : 0))
        // it's not clear to me what you want here. Without any Select, each full grouping will get
        // pulled into memory as an IGrouping. If instead you just want the Column1 values, you'd
        // want .Select(g => g.Key)
        .Select(...);
