    DBContext.Set<AccountMember>()
        .Include(am => am.Account)
        .Select(am => new
        {
            am.ID,
            am.IsPrimary,
            Account = new { am.Account.ID, am.Account.DoNotEmail }
        });
