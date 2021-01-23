    public bool AddIfEmpty(T item)
    {
        lock (innerList)
        {
            if (innerList.Count == 0)
            {
                innerList.Add(item);
                return true;
            }
            return false;
        }
    }
