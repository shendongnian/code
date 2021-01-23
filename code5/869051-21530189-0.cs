    ISession session = sessionFactory.OpenSession();
    ITransaction tx = session.BeginTransaction();
    
    string hqlDelete = "delete ObjectA a where a.property = :someValue";
    
    int deleteddEntities = s.CreateQuery( hqlDelete )
       .SetString( "someValue", someValue)
       .ExecuteUpdate();
    
    tx.Commit();
    session.Close();
