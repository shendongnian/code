    public static void SaveLaterMessages(MSG msg)
    {
        var dic = Globals.DIC_PROFILEID__MSGS;
        List<MSG> existingLst = dic.GetOrAdd(msg.To, (key) => new List<MSG>());
        
        var lockingObj = GetLockingObject(existingLst);
        lockingObj.EnterWriteLock();
        try
        {
            existingLst.Add(msg);
        }
        finally
        {
            lockingObj.ExitWriteLock();
        }
    }
    private static ConcurrentDictionary<List<MSG>, ReaderWriterLockSlim> _msgLocks = new ConcurrentDictionary<List<MSG>, ReaderWriterLockSlim>();
    public static ReaderWriterLockSlim GetLockingObject(List<MSG> msgList)
    {
        _msgLocks.GetOrAdd(msgList, (key) => new ReaderWriterLockSlim());
    }
    //Elsewhere in multiple threads.
    public MSG PeekNewestMessage(int myId)
    {
        var dic = Globals.DIC_PROFILEID__MSGS;
        var list = dic[myId];
        var lockingObj = GetLockingObject(list);
    
        lockingObj.EnterReadLock();
        try
        {
            return list.FirstOrDefault();
        }
        finally
        {
            lockingObj.ExitReadLock();
        }
    }
