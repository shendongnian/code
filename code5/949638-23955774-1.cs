    var contractLines = (from cl in context.CreateQuery<ContractDetail>()
      join a in context.CreateQuery<Account>()
      on cl.CustomerId.Id equals a.AccountId                                 
      where cl.StateCode.Value == 0
      select new {cl, a}).ToList();
    var collection = new EntityCollection();
    foreach (var line in contractLines)
    {
        if (line.a.Name == line.cl.dbc_SupportedBy)
        {
            collection.Entities.Add(line.cl);
        }
    }
