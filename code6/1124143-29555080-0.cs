    public Customer Get(Expression<Func<Customer, bool>> where)
    {
        return GetHelper(EntityType.Customer, where, customerRepository.Get);
    }
    public static T GetHelper<T>(EntityType type, Expression<Func<T, bool>> where, 
                                 Func<Expression<Func<T, bool>>, T> repositoryAccessor) 
        where T : IHasGroup
    {
        var addGroup = groupRepository.Get(type).AddGroup;
        if (addGroup)
            where = where.And(x => x.GroupId == user.GroupId);
    
        return repositoryAccessor(where);
    }
