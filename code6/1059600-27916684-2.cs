    ISession session = sessionFactory.OpenSession();
    ITransaction tx = session.BeginTransaction();
    
    var hqlInsert = ... // see code above to create DML HQL
    int createdEntities = session
         .CreateQuery( hqlInsert )
         .ExecuteUpdate();
    tx.Commit();
    session.Close();
