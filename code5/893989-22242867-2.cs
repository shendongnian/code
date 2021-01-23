    Repository.Query<Actor>().Where(a => a.Id == actorId).SelectMany(a => a.BankAccounts).Where(ba => BankAccounts.Any(ac => ac.Id == ba.Id)).Select(ba => new BankAccountModel
        {
            IbanPrefix = ba.IbanPrefix,
            Id = ba.Id,
            Number = ba.Number
        });
