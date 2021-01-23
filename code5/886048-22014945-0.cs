    using (NHibernate.ISession session = SessionFactory.GetCurrentSession())
    {
        using (NHibernate.ITransaction tran = session.BeginTransaction())
        {
            doc.FactorDocDetails.Clear();
            tran.Commit();
        }
    }
