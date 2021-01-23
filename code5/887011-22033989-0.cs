    public static List<Users> SortUsers(string sSortBy)
    {
        var arg = Expression.Parameter(typeof(Users), "Users");
        var sortProperty = Expression.Property(arg, sSortBy);
        var lambda = Expression.Lambda(sortProperty, arg);
        var param = Expression.Parameter(typeof(IQueryable<Users>));
        var orderByCall = Expression.Call(typeof(Queryable), "OrderBy", new Type[] { typeof(Users), sortProperty.Type }, new Expression[] { param, lambda });
        var orderLambda = Expression.Lambda<Func<IQueryable<Users>, IQueryable<Users>>>(orderByCall, param).Compile();
        List<Users> UserList;
        UserList = orderLambda(UOWUser.UsersRepository.Entities).ToList(); // Error here
        return UserList;
    }
