    private void AddInternal(ConcurrentBag<T>.ThreadLocalList list, T item)
    {
      bool lockTaken = false;
      try
      {
        Interlocked.Exchange(ref list.m_currentOp, 1);
        if (list.Count < 2 || this.m_needSync)
        {
          list.m_currentOp = 0;
          Monitor.Enter((object) list, ref lockTaken);
        }
        list.Add(item, lockTaken);
      }
      finally
      {
        list.m_currentOp = 0;
        if (lockTaken)
          Monitor.Exit((object) list);
      }
    }
