    public static Expression<Func<Item, bool>> GetFilter(
        TimeSpan fromValue, TimeSpan toValue)
    {
        Expression<Func<Item, Contract>> currentContract =
            q => q.StaffContracts
                    .OrderByDescending(p => p.SignedDate)
                    .Where(p => p.Active)
                    .FirstOrDefault();
        return currentContract.Compose(contract =>
            contract != null &&
            contract.TimeSpan >= fromValue &&
            contract.TimeSpan <= toValue);
    }
