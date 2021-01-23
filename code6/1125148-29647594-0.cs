    private static IEnumerable<Entity> GetActiveAccounts(OrganizationServiceContext serviceContext)
    {
        string fetchXml = serviceContext
            .CreateQuery("savedquery")
            .Where(sq =>
                sq.GetAttributeValue<Guid>("savedqueryid") == new Guid("00000000-0000-0000-00AA-000010001002"))
            .Select(sq => sq.GetAttributeValue<string>("fetchxml"))
            .First();
        var request = new RetrieveMultipleRequest
        {
            Query = new FetchExpression(fetchXml)
        };
        var response = (RetrieveMultipleResponse) serviceContext.Execute(request);
        return response.EntityCollection.Entities;
    }
