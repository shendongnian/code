    RetrieveEntityRequest entityRequest = new RetrieveEntityRequest
    {
        EntityFilters = EntityFilters.Attributes,
        LogicalName = entityName,
        RetrieveAsIfPublished = true
    };
    RetrieveEntityResponse entityResponse = (RetrieveEntityResponse)serviceProxy.Execute(entityRequest);
