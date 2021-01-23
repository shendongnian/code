     if (!string.IsNullOrWhiteSpace(accountHolderName))
        {
          Customer  cust = _entities.Customers.FirstOrDefault(c => c.AccountId == acct.AccountId &&
                                                             c.CorporationId == token.CorporationId &&
                                                             c.Name.Replace(" ","").ToUpper().StartsWith(accountHolderName.Replace(" ","").ToUpper()));
        }
