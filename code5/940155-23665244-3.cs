    var AgeList = new List<string>();
    //retrieve BirthDate from SQL Server and use ToList() to get it to run immediately
    var AgeListQry = (from d in db.Actors orderby d.BirthDate select d.BirthDate).ToList();
    //convert them after the fact, using Linq to Objects
    AgeList.AddRange(AgeListQry.Select(bd => (int)(DateTime.Now - bd).TotalDays / 365).Distinct());
