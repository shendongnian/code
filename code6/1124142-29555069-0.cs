    public IGroup Get(Expression<Func<IGroup, bool>> where)
    {
        var addGroup = groupRepository.Get(EntityType.Customer).AddGroup;
        if (addGroup)
            where = where.And(x => x.GroupId == user.GroupId);
    
        return customerRepository.Get(where);
    }
