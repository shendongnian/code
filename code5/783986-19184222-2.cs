    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        var query = _unitOfWork.CurrentSession.Query<TEntity>();
        return query.Where(predicate).Future<TEntity>();
    }
