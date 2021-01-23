    What you doing is right, but the only thing is, you need the evict the entity from session using which you fetched the data. Do something like this
        sessionWhichFetchedTheData.evict(item)
        
        private ISession session = NHibernateConnexion.OpenSession();
        using (var transaction = session.BeginTransaction()
        {
            session.Update(item);
            transaction.Commit();
        }
