    var AgeList = new List<string>();
    //retrieve as ints, no conversion in SQL Server
    var AgeListQry = (from d in db.Actors orderby d.Age select d.Age).ToList();
    //convert them after the fact, using Linq to Objects
    AgeList.AddRange(AgeListQry.Select(a => a.ToString()).Distinct());
