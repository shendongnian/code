    using (var ctx = new ClientContext(webUrl))
    {
        ctx.ExecuteQuery();
        var version = ctx.ServerLibraryVersion;
    }
