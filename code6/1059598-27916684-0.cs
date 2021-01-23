    ISession session = sessionFactory.OpenSession();
    ITransaction tx = session.BeginTransaction();
    
    var hqlInsert = "insert into DelinquentAccount (id, name) " + 
                    " select c.id, c.name from Customer c where ...";
    int createdEntities = s.CreateQuery( hqlInsert )
            .ExecuteUpdate();
    tx.Commit();
    session.Close();
