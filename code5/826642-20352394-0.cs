    public static Expression<Func<User, bool>> IsUserActive = user =>
        user.Orders.Any(c => c.Active &&
                             (c.TransactionType == TransactionType.Order ||
                              c.TransactionType == TransactionType.Subscription));
    public IQueryable<UserView> GetView()
    {
        return context.users.Select(p => new UserView
            {
                Id = p.Id,
                Active = IsUserActive(p)
            });
    }
