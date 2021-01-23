    using (var servicecontext = CrmConfigurationManager.CreateContext("MyOnPremiseConnection", true) as CrmOrganizationServiceContext)
    {
        var query = new QueryExpression
        {
            EntityName = "account",
            ColumnSet = new ColumnSet("name"),
            TopCount = 10,
        };
        var top10accounts = servicecontext.RetrieveMultiple(query).Entities;
    }
