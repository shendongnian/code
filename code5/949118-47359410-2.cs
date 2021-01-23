    using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled)) {
        // important - use EF connection string here,
        // one that starts with "metadata=res://*/..."
        var efConnectionString = ConfigurationManager.ConnectionStrings["SomeEntities"].ConnectionString;
        // note EntityConnection, not SqlConnection
        using (var conn = new EntityConnection(efConnectionString)) {
            // important to prevent escalation
            await conn.OpenAsync();
            using (var c1 = new SomeEntities(conn, contextOwnsConnection: false)) {
                //Use some stored procedures etc.
                count1 = await c1.SomeEntity1.CountAsync();
            }
            using (var c2 = new SomeEntities(conn, contextOwnsConnection: false)) {
                //Use some stored procedures etc.
                count2 = await c2.SomeEntity21.CountAsync();
            }
        }
        scope.Complete();
    }
