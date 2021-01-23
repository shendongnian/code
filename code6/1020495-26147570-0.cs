    ISession session = sessionFactory.OpenSession();
    ITransaction tx = session.BeginTransaction();
    
    string hqlUpdate = "update Customer c set c.name = :newName where c.name = :oldName";
    // or string hqlUpdate = "update Customer set name = :newName where name = :oldName";
    int updatedEntities = s.CreateQuery( hqlUpdate )
            .SetString( "newName", newName )
            .SetString( "oldName", oldName )
            .ExecuteUpdate();
    tx.Commit();
    session.Close();
