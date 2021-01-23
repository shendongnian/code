    var repository = Substitute.For<IRepository>();
    var cache = Substitute.For<IQueryCache>();
    repository.GetUserItems(query).Returns(expected);
    cache.GetOrExecute(query, () => repository.GetUserItems(query)).Returns(expected);
    var handler = new RequestHandler(repository, cache);
