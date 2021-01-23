    ISession session = sessionFactory.OpenSession();
    ITransaction tx = session.BeginTransaction();
    
    String hqlDelete = "delete Customer c where c.name = :oldName";
    // or String hqlDelete = "delete Customer where name = :oldName";
    int deletedEntities = s.CreateQuery( hqlDelete )
            .SetString( "oldName", oldName )
            .ExecuteUpdate();
    tx.Commit();
    session.Close();
