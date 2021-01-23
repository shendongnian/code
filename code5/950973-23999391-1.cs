    public void Update<T>(
        T entity, params Expression<Func<T, Object>>[] selectors)
        where T : class
    {
        _context.Set<T>().Attach(entity);
        var members = selectors.SelectMany(
            selector => selector.GetPropertyAccesses());
        foreach (var member in members)
            _context.Entry<T>(entity)
                .Property(member.Member.Name)
                .IsModified = true;
    }
