    public virtual IQueryable<TDto> Assemble(IQueryable<TEntity> domainEntityList)
    {
        List<TDto> dtos = Activator.CreateInstance<List<TDto>>();
        foreach (TEntity domainEntity in domainEntityList)
        {
            dtos.Add(Assemble(domainEntity));
        }
        return dtos.AsQueryable();
    }
