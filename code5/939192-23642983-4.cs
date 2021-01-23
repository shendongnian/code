    using (var ctx = new MyContext())
    {
        // he added this well-known line to get better performance!
        ctx.Configuration.AutoDetectChangesEnabled = false;
        var bankAccount123 = ctx.BankAccounts.Include(b => b.Deposits)
            .Single(b => b.AccountNumber == 123);
        var bankAccount456 = ctx.BankAccounts
            .Single(b => b.AccountNumber == 456);
        var deposit = bankAccount123.Deposits.Single();
        deposit.BankAccountId = bankAccount456.Id;
        ctx.BankAccounts.Remove(bankAccount123);
        // he heard this line would be required when AutoDetectChanges is disabled!
        ctx.ChangeTracker.DetectChanges();
        ctx.SaveChanges();
    }
