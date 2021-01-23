    public static Expression<Func<Item, bool>> GetWhere(TimeSpan fromValue, TimeSpan toValue)
    {
        Expression<Func<Item, Contract>> currentContract =
            q => q.StaffContracts
                  .OrderByDescending(p => p.SignedDate)
                  .Where(p => p.Active)
                  .FirstOrDefault();
        var param = currentContract.Parameters.First();
        return Expression.Lambda<Func<Item, bool>>(
                    Expression.And(
                        Expression.And(
                            Expression.NotEqual(
                                currentContract,
                                Expression.Constant(null, typeof(Contract))),
                            Expression.GreaterThanOrEqual(
                                Expression.Property(currentContract, "Timespan"),
                                Expression.Constant(fromValue))),
                        Expression.LessThanOrEqual(
                            Expression.Property(currentContract, "Timespan"),
                            Expression.Constant(toValue))),
                    param);
    }
