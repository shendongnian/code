    var books = context.Books; //or whatever
    var query = books.Where(b => b.Name == "Something");
    
    // You can build up a query by chaining more operataions
    // on to it
    query = query.Where(b => b.PublishDate < DateTime.Today);
    query = query.OrderBy(b => b.Id);
    
    // Your ORM may be able to handle the StartsWith, EndsWith, 
    // Contains string methods. Check its documentation.
    query = query.Where(b => b.Name.StartsWith("The"))
    // Since the query object implements IQueryable, it can translate into
    // two appropriate SQL queries.
    return query.ToPagedList(2, 50);
