    using( ISession s = sessionFactory.BeginSession()){
        using( ITransaction t = s.StartTransaction()){
            // do some work
            t.Commit();
        }
    }
