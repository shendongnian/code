    Public SomeMethod()
    {
         slqParameters[] parameters = new Parameters[1]
        {
            new sqlParameters{ ParamData  = , paramKey = "@CName", ParamDatabaseType  = NewClient.CName}
        };
    
        db.ExecuteStoreProcedure("Store Procedure name", parameters);
    }
