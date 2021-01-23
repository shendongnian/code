    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                 CancellationToken cancellationToken)
    {
        // Logic here to parse the request, send off the request, and then parse the response for logging info
        // Log to database
        using (MyEntities myEntities = _container.Resolve<MyEntities>("MyEntitiesTransient"))
        {
            // Log to database using MyEntities (DbContext)
            _container.Release(bradyEntities);
        }
        return response;
    }
