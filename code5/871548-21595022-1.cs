    public IQueryable<Users> SelectAll<TProp>(string sSortExpression, string sSortOrder)
    {
        var param = Expression.Parameter(typeof(Users));
        var propExpression = Expression.Lambda<Func<Users, TProp>>(Expression.Property(param, sSortExpression), param);
        if (sSortOrder == "asc")
        {
            return UsersRepository.Entities.OrderBy(propExpression);
        }
        else
        {
            return UsersRepository.Entities.OrderByDescending(propExpression);
        }
    }
