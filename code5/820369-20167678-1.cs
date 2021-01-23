    protected override void Initialize(RequestContext requestContext)
    {
        var tableId = Convert.ToUInt32(requestContext.RouteData.GetRequiredString("tableId"));
        L = Lobby.Instance;
        T = L.Tables[tableId];
        base.Initialize(requestContext);
    }
