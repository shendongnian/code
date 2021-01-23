    using ( var ctx = new JanathaPosDbContext() )
    {
        // access the data 
        var roles = ctx.UserRoles.ToList();         
        // or force the initialization
        ctx.Database.Initialize( true );
    }
