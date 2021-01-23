    from c in Clients
    let vipCount = c.Subscriptions.SelectMany(s => s.ClientAccesses).Count()
    let listCount = c.GuestListClients.Count()
    select new FilterClientsResult {
            c.ClientId,
            ...
            Type = vipCount > 0 ? listCount > 0 ? ClientType.ALL 
                                                : ClientType.VIP 
                                : listCount == 0 ? 0 
                                                 : ClientType.LIST,
            Visits  = vipCount + listCount
        }
