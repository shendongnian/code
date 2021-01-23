    using (ISession session = _sessionFactory.OpenSession())
    {
        ParentEntity[] arr;
        int i = _rand.Next(arr.Count());
        using (var transaction = session.BeginTransaction())
        {
            arr = session.CreateQuery("from ParentEntity")
                .List<ParentEntity>().ToArray();
            ParentEntity par = arr[i];
            par.data += " modified at " + DateTime.Now.ToString();
            session.SaveOrUpdate(par);
            transaction.Commit();
        }
    }
