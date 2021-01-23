    Internal class AccountService
    {
        Public Account GetAccount(string firstName)
        {
            var results = Enumerable.Empty<Account>();
    
            try
            {
                 var repository = new Repository<Account>(); // I use and interface here and                    
                                                             // then a factory class. I just
                                                             // was trying to keep it simple.
                 results = repository.FindAll()
                     .Where(a => a.FirstName == firstName)
                     .ToList();
            }
            catch()... etc.
    
            return results;
        }
    }
    
    Public interface IAccountService
    {
        Account GetAccount(string accountNumber);
    }
