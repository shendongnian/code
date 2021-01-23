    var result = db.table
    .Select(t =>
    {
        ID = t.ID,
        Name = t.Name,
        City = t.City
    })        // project only used columns, to reduce data from db => web server
    .ToList() // convert from Linq-To-Entities, to Linq-To-Objects
    .GroupBy(t => new
    {
        ID = t.ID,
        Name = t.Name,
        City = t.City
    })
    .Select(g => g.Key)
