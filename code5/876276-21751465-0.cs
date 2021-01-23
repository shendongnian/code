    var objectContext = ((IObjectContextAdapter)DbContext).ObjectContext;
    var query = (System.Data.Objects.ObjectQuery)objectContext.CreateObjectSet<User>().Where(u => u.Id != Guid.Empty);
    var initialQueryString = query.ToTraceString();
    var resultQueryString = initialQueryString + " order by [dbo].[MySQLFunction]";
    
    //careful here, if you use MS SQL you need to use SqlParameter instead of NpgsqlParameter
    var paramValues = new List<NpgsqlParameter>();
    foreach (var param in query.Parameters)
    {
    	paramValues.Add(new NpgsqlParameter(param.Name, param.Value));
    }
    
    var result = objectContext.ExecuteStoreQuery<User>(resultQueryString, paramValues.Cast<object>().ToArray()).ToList();
