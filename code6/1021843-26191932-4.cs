     var hierarchyQuery = new SQLCriterion(
                              new SqlString("{alias}.id IN (SELECT Id FROM dbo.fnGetParents(?))"),
                              new object[] {id}, 
                              new[] {NHibernateUtil.Int32});
     var results = session.QueryOver<Hierarchy>()
              .Where(hierarchyQuery)
              .List();
