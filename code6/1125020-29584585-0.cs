    var result = new Stuff { A = "a", B = "b" };
    IQueryable<Stuff> query = client.CreateDocumentQuery<Stuff>(collectionLink);
    if (result != null)
    {
        query = query.Where(s => s.A == result.A);
        query = query.Where(s => s.B == result.B);
    }
    int numResults = query.AsEnumerable().Count();
    if (numResults > 0)
    {
        // DoSomething();
    }
