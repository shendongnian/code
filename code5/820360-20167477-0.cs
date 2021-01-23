    string roleName = "System Administrator";
    
    QueryExpression query = new QueryExpression("systemuser");
    
    query.ColumnSet = new ColumnSet(new string[] { "systemuserid" });
    query.Distinct = true;
    query.Criteria = new FilterExpression();
    query.AddLink("systemuserroles", "systemuserid", "systemuserid").
    AddLink("role","roleid", "roleid").LinkCriteria.AddCondition("name", ConditionOperator.Equal, roleName);
    
    var users = organizationService.RetrieveMultiple(query);
    
    if (users.Entities.Count() > 0) return ((Entity)users[0]).ToEntityReference();
 
