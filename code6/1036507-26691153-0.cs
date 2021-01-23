    sessionWhichFetchedTheData.evict(item)
    
    
    private ISession session = NHibernateConnexion.OpenSession();
    using (var transaction = session.BeginTransaction()
    {
        session.Update(item);
        transaction.Commit();
    }
