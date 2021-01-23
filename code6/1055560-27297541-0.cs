    if (found)
    {
        lock ( _listLock )
        {
            list.Remove(value);
            if (list.Count == 0)
            {
                // warning: possible race condition here
                dict.TryRemove(key, out list);
            }
        }
    }
