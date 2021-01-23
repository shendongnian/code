    protected virtual ISpecification<TEntity> ByMultipleKeysSpecification(IEnumerable<TKey> keys) 
    {
        return keys.Select(key => (Expression<Func<TEntity, bool>>)(entity => key.Equals(entity.Id)))
            .Aggregate<Expression<Func<TEntity, bool>>, ISpecification<TEntity>>(null,
                (current, lambda) => current == null ? new Specification<TEntity>(lambda) : current.Or(lambda)
            );
    }
