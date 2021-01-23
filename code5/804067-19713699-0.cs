    IList<Item> list;
    using(var session = sessionFactory.OpenSession())
    {
        list = session.QueryOver<Item>().Fetch(x => x.User).Eager.List();
    }
    var otherStuff = list.Select(x => x.OtherItem.Price).ToList(); // Boom, exception! OtherItem was not eagerly fetched.
