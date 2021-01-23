    QueryExpression query = new QueryExpression
    {
    	LogicalName = "contact",
    	...
    }
    
    RetrieveMultipleRequest rmr = new RetrieveMultipleRequest()
    {
    	Query = query,
    	ReturnDynamicEntities = true
    };
    
    RetrieveMultipleResponse rmrresp = ServiceProxy.Execute(rmr) as RetrieveMultipleResponse;
    BusinessEntityCollection response = rmrresp.BusinessEntityCollection;
    Logify("count: " + response.BusinessEntities.Count);
    BusinessEntity piff= response.BusinessEntities.First();
    Logify("piff: " + (piff != null));
    
    DynamicEntity poof = response.BusinessEntities.First() as DynamicEntity;
    Logify("poof: " + (poof != null));
