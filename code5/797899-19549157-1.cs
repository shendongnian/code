    using( ISession s = sessionFactory.OpenSession()){
        using( ITransaction t = s.BeginTransaction()){
            // do some work
            t.Commit();
        }
    }
