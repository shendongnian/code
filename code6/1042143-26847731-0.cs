    private TEntity GetFromStore(TKey key)
    {
        var lambda = Expression.Lambda<Func<TEntity, bool>>(
            Expression.Equal(
                _selector.Body,
                Expression.Constant(key)
                )
            , _selector.Parameters[0]);
        return _repository.FirstOrDefault(lambda);
    }
