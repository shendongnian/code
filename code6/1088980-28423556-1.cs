	    Users users = null;
        UserRoles userRoles = null;
    
            
        var query = session.QueryOver(() => userRoles)
            .JoinQueryOver(() => userRoles.Users, () => users)
            .Where(() => users.Username == "test")
            .Select(r => r.Roles)
            .TransformUsing(Transformers.DistinctRootEntity);
    
        var results = query.List();
            
