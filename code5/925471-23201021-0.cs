    // the source xml snippet            
    var xml = "<ScopeIds><id>417444AC-6C57-4CB7-91E1-6E0B5832EDBB</id></ScopeIds>";
    // this SQL statement will represent the xml creation and call to '.exist'
    var sql = " CAST('" + xml + "' AS xml)" +
              "     .exist('/ScopeIds[id=sql:column(\"ScopeId\")]') " +
              " AS idExists";
    // here we declare the SQL Project, NHibernate how to manage low level sql
    var projection = Projections.SqlProjection( sql
                , new string[] {"idExists"}
                , new IType[] {NHibernateUtil.Int32}
                );
    // the criteria
    var criteria = session.CreateCriteria<MyEntity>();
   
    // and here we compare the above restriction if == 1 (is true)
    criteria.Add(Restrictions.Eq(projection, 1));
    // all other restrictions
    ...
