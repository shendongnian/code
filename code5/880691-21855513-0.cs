    var query = from c in db.Client
                where c.MetaProps.Deleteflag == 0
                && c.ContractNumber.Equals(clientNumber)
                select new
                {
                    Client = c,
                    Accounts = c.Accounts.Where(a => a.IsActive) ?? Enumerable.Empty<Account>()  
                };
    contract = query.FirstOrDefault().Client;
