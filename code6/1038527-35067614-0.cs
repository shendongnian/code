        static ConcurrentDictionary<string, object> _lockDict =
            new ConcurrentDictionary<string, object>();
        public void MethodWithExclusiveAccessToSpecificResource(string resourceId)
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
                        // ... open/use resource identified by resourceId ...
                    }
                }
            }
            while (!isSameLock);
        }
        public void RemoveLockFromDictionaryAndCloseResource(string resourceId)
        {
            object lockObj, lockObjCheck;
            if (_lockDict.TryGetValue(resourceId, out lockObj))
            {
                lock (lockObj)
                {
                    if (_lockDict.TryGetValue(resourceId, out lockObjCheck) && 
                        (lockObj == lockObjCheck))
                    {
                        _lockDict.TryRemove(resourceId, out lockObjCheck);
                        // ... close resource identified by resourceId ...
                    }
                }
            }
        }
