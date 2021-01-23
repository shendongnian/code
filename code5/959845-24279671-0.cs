    Guid accountId = new Guid("90F8889F-EB95-E781-8417-000C44420CBC");
    Guid newOwnerId = new Guid("A8AA28B4-9015-DF11-8062-000E0CA08051");
    
    AssignRequest assignRequest = new AssignRequest
            {
                Assignee = new EntityReference("systemuser", newOwnerId),
                Target = new EntityReference("account", accountId)
            };
    service.Execute(assignRequest);
