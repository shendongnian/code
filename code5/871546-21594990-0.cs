    public IQueryable<Users> SelectAllByCompany(string sSortExpression, string sSortOrder)
    {
        var p = Expression.Parameter(typeof(Users),"u");
        var sortExpr = Expression.Lambda<Func<User,object>>(Expresion.Property(p,sSortExpression), p);
 
        if (sSortOrder == "asc")
        {
            return UsersRepository.Entities.OrderBy(sortExpr);
        }
        else
        {
            return UsersRepository.Entities.OrderByDescending(sortExpr);
        }
    }
