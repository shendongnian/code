    // clientId is the currently logged on.
    // Typically, this would be passed into your data access code
    // from your business layer.
    int clientId = 1;
    var query = for someTable as Entities.SomeTable
        where (someTable.ClientID == clientId)
        select someTable
