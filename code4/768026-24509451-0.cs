    Mapper.Initialize(cfg =>
    {
        cfg.ConstructServicesUsing(serviceTypeToConstruct =>
        {
            var httpRequestMessage = HttpContext.Current.Items["MS_HttpRequestMessage"] as HttpRequestMessage;
            var currentDependencyScope = httpRequestMessage.GetDependencyScope();
            return currentDependencyScope.GetService(serviceTypeToConstruct);
        });
        // configure mappings
        // ...
    });
