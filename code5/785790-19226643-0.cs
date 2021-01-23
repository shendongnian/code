    var det = DetachedCriteria.For<T>.Add(Restrictions.Eq(prop, val));
    using (var session = Config.OpenSession())
    using (var txn = session.BeginTransaction())
    {
        var result= det.GetExecutableCriteria(session).List();
    }
