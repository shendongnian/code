    public int IndexOf(T item)
    {
        Contract.Ensures(Contract.Result<int>() >= -1);
        Contract.Ensures(Contract.Result<int>() < Count);
        return Array.IndexOf(_items, item, 0, _size);
    }
