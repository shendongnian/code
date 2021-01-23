    Repository
     .Query<Actor>()
     .Where(a => a.Id == actorId)
     .SelectMany(a => a.BankAccounts)
     .Select(ba => new BankAccountModel
                       {
                           IbanPrefix = ba.IbanPrefix,
                           Id = ba.Id,
                           Number = ba.Number
                       }
            );
