    listDataSource = db.QCs
        .Where(j => j.SUBJECT != null)
        .GroupBy(i => i.SUBJECT) //no need to create an anonymous type, you don't use it afterwards
        .Select(group => new { SUBJECT = group.Key, Count = group.Count()}) //counting in SQL is faster
        .AsEnumerable() //materialization, all the heavy lifting is performed by SQL until now
        .Select(value => //seems redundant, but the previous selection just translates into an SQL select statement with SUBJECT and Count columns
            new chart
            {
                date = value.SUBJECT,
                Count = value.Count.ToString()
            })
        .ToList();
