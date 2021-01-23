    ISession session = sessionFactory.OpenSession();
    ITransaction tx = session.BeginTransaction();
    
    String hqlDelete = "delete Children c where c.ParentId = :parentId";
    int deletedEntities = s.CreateQuery( hqlDelete )
            .SetString( "parentId", parentId )
            .ExecuteUpdate();
    tx.Commit();
    session.Close();
