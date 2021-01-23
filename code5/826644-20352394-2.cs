    public static Expression<Func<User, UserView>> UserToUserView = user =>
        new UserView
            {
                Id = user.Id,
                Active =  user.Orders.Any(c => c.Active &&
                             (c.TransactionType == TransactionType.Order ||
                              c.TransactionType == TransactionType.Subscription)
            };
    public IQueryable<UserView> GetView()
    {
        return context.users.Select(UserToUserView);
    }
