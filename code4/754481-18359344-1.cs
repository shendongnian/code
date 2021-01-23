    var interceptor = new SqlRegionInterceptor ();
    using (var session = sessionFactory.OpenSession(interceptor))
    {
        var customers = session.QueryOver<Customer>.List();
        ...
        session.Close();
    }
