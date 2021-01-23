    private EntityCollection getAddresses(Guid AccountID, IOrganizationService service)
    {
        QueryExpression query = new QueryExpression("customeraddress");
        query.ColumnSet = new ColumnSet(true);
        query.Criteria.AddCondition("parentid", ConditionOperator.Equal, AccountID);    
        EntityCollection results = service.RetrieveMultiple(query);
        return results;
    }
