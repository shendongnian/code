    private IEnumerable<Entity> GetActiveAccounts(int pageNumber)
    {
        string fetchXml = _serviceContext
            .CreateQuery("savedquery")
            .Where(sq =>
                sq.GetAttributeValue<Guid>("savedqueryid") == new Guid("00000000-0000-0000-00AA-000010001002"))
            .Select(sq => sq.GetAttributeValue<string>("fetchxml"))
            .First();
        var conversionRequest = new FetchXmlToQueryExpressionRequest
        {
            FetchXml = fetchXml
        };
        var response = (FetchXmlToQueryExpressionResponse)_serviceContext.Execute(conversionRequest);
        response.Query.PageInfo = new PagingInfo { Count = 1, PageNumber = pageNumber };
        var queryRequest = new RetrieveMultipleRequest
        {
            Query = response.Query
        };
        var result = (RetrieveMultipleResponse) _serviceContext.Execute(queryRequest);
        return result.EntityCollection.Entities;
    }
