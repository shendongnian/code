    if (_inMemory)
    {
        if (_query != null && _query.HasOrderBy())
            _result = new InMemoryBTreeCollection<T>(_query.GetOrderByType());
        else
            _result = new SimpleList<T>();
    }
    else
    {
        // result = new InMemoryBTreeCollection((int) nbObjects);
        if (_query != null && _query.HasOrderBy())
            _result = new LazyBTreeCollection<T>(_storageEngine, _returnObjects);
        else
            _result = new LazySimpleListFromOid<T>(_storageEngine, _returnObjects);
    }
