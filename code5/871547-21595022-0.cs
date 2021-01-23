    public IQueryable<Users> SelectAll<TProp>(Expression<Func<Users, TProp>> selector, string sSortOrder)
    {
        if (sSortOrder == "asc")
        {
            return UsersRepository.Entities.OrderBy(selector);
        }
        else
        {
            return UsersRepository.Entities.OrderByDescending(selector);
        }
    }
