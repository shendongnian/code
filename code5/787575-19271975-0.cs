    public object Get(int id)//same for the other one based on name
    {
       lock.AcquireReaderLock(Timeout.Infinite);
       try{
          if(cacheID.Contains(id)){return cacheID[id];}
          LockCookie lk = lock.UpgradeToWriterLock(Timeout.Infinite);
          try{
              if(cacheID.Contains(id)){return cacheID[id];}//check again!!!
              
              //item not in cache
              //1. fetch from db
              //2. insert in cacheID
              //3. insert in cacheName
              //return value  
          }finally{lock.DowngradeFromWriterLock(ref lk);}
       }
       finally{lock.ExitReadLock();}
    }
