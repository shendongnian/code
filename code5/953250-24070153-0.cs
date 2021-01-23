    public TEntity[] Compute<TEntity>(TEntity[] array, Func<TEntity, TEntity> operation)
    {
        return array.Select(operation).ToArray();
    }
    public TEntity[] Compute<TEntity>(TEntity[] array1, TEntity[] array2, Func<TEntity, TEntity, TEntity> operation)
    {
        if (array1.Length != array2.Length)
            throw new ArgumentException();
        return Enumerable.Range(0, array1.Length).Select(index => operation(array1[index], array2[index])).ToArray();
    }
