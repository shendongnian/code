    //Retrieve "Primary" account type
    QueryExpression query = new QueryExpression("new_accounttype");
    query.Criteria.AddCondition("new_name", ConditionOperator.Equal, "Primary");
    Entity accountType = service.RetrieveMultiple(query).Entities.First();
    
    //Set the lookup as Guido described above
    Account acc = new Account();
    acc.Attributes["name"] = "Ram";
    acc.Attributes["age"] = "22";
    acc.Attributes["lookupfieldid"] = new EntityReference("new_accounttype", accountType.Id);
    service.Create(acc);
