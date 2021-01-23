    public IEnumerable<User> GetActive(Func<IQueryable<User>, IQueryable<User>> modifier)
    {
        var users = modifier(context.Set<UserTbl>().Where(x => x.IsActive));
    
        foreach(var user in users)
        {
            yield return entityMapper.CreateFrom(user);
        }
    }
    
    // Get only 5 users in memory
    var someUsers = UserRepository.GetActive(q=>q.Take(5)).ToList();
    
    // Get all 100,000 users into memory
    var allUsers = UserRepository.GetActive(q=>q).ToList();
