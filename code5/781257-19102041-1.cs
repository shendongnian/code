    public void Add(object item)
    {
        lock (_innerList)
        {
            _innerList.Add(item);
        }
    }
