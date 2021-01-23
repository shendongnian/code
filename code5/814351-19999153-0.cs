    DetachedCriteria dCriteria = DetachedCriteria.For<UserRole>("ur")
        .SetProjection(Projections.Property("ur.UserId"))
        .Add(Restrictions.EqProperty("ur.UserId", "user.Id"))     
        .Add(Restrictions.Eq("ur.Role", query.Role));
    
    var criteria = nhSession.CreateCriteria<User>("user")
        .Add(Subqueries.Exists(dCriteria)).List<User>();
               
