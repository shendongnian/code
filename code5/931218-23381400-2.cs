    public IEnumerator<T> GetEnumerator()
    {
        // Short path if the bag is empty
        if (m_headList == null)
            return new List<T>().GetEnumerator(); // empty list
 
        bool lockTaken = false;
        try
        {
            FreezeBag(ref lockTaken);
            return ToList().GetEnumerator();
        }
        finally
        {
            UnfreezeBag(lockTaken);
        }
    }
    private List<T> ToList()
    {
        Contract.Assert(Monitor.IsEntered(GlobalListsLock));
 
        List<T> list = new List<T>();
        ThreadLocalList currentList = m_headList;
        while (currentList != null)
        {
            Node currentNode = currentList.m_head;
            while (currentNode != null)
            {
                list.Add(currentNode.m_value);
                currentNode = currentNode.m_next;
            }
            currentList = currentList.m_nextList;
        }
 
        return list;
    }
