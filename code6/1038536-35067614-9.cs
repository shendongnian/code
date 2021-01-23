        static ConcurrentDictionary<string, object> _lockDict =
            new ConcurrentDictionary<string, object>();
        // VERSION 1: single-shot method
        public void UseAndCloseSpecificResource(string resourceId)
        {
            bool isSameLock;
            object lockObj, lockObjCheck;
            do
            {
                lock (lockObj = _lockDict.GetOrAdd(resourceId, new object()))
                {
                    if (isSameLock = (_lockDict.TryGetValue(resourceId, out lockObjCheck) && 
                                     (lockObj == lockObjCheck)))
                    {
                        // ... open, use, and close resource identified by resourceId ...
                        // This must be the LAST statement
                        _lockDict.TryRemove(resourceId, out lockObjCheck);
                    }
                }
            }
            while (!isSameLock);
        }
        // VERSION 2: separated "use" and "close" methods
        //            (can coexist with version 1)
        public void UseSpecificResource(string resourceId)
        {
            bool isSameLock;
            object lockObj, lockObjCheck;
            do
            {
                lock (lockObj = _lockDict.GetOrAdd(resourceId, new object()))
                {
                    if (isSameLock = (_lockDict.TryGetValue(resourceId, out lockObjCheck) && 
                                     (lockObj == lockObjCheck)))
                    {
                        // ... open and use (or reuse) resource identified by resourceId ...
                    }
                }
            }
            while (!isSameLock);
        }
        public void CloseSpecificResource(string resourceId)
        {
            object lockObj, lockObjCheck;
            if (_lockDict.TryGetValue(resourceId, out lockObj))
            {
                lock (lockObj)
                {
                    if (_lockDict.TryGetValue(resourceId, out lockObjCheck) && 
                        (lockObj == lockObjCheck))
                    {
                        // ... close resource identified by resourceId ...
                        // This must be the LAST statement
                        _lockDict.TryRemove(resourceId, out lockObjCheck);
                    }
                }
            }
        }
