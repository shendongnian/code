    var entities = new[] { 
        new MyEntity { Status = Status.Accepted }, 
        new MyEntity { Status = Status.Pending }, 
        new MyEntity { Status = Status.Rejected } 
    }.AsQueryable();
    var query = from e in entities.LanguageSort("EN")
                select e;
    var queryJp = from e in entities.LanguageSort("JP")
                  select e;
    Console.WriteLine("Sorting with EN");
    foreach (var e in query)
        Console.WriteLine(e.Status);
    Console.WriteLine("Sorting with JP");
    foreach (var e in queryJp)
        Console.WriteLine(e.Status);
