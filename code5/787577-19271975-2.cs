    public class MyCache{
       private ReaderWriterLock rwlock;
..................
    public object Get(int id)//same for the other one based on name
    {
       rwlock.AcquireReaderLock(Timeout.Infinite);
       try{
          if(cacheID.Contains(id)){return cacheID[id];}
          //item MIGHT not be in cache (not certain since we're still under read lock)
          //1. fetch from db BEFORE upgrade to write - avoid blocking all other readers
          var item = GetItemFromStorage(id);//you get the idea
          LockCookie lk = rwlock.UpgradeToWriterLock(Timeout.Infinite);
          try{
              if(cacheID.Contains(id)){return cacheID[id];}//check again!!!
              
              //2. insert in cacheID
              cacheID[id]=item;
              //3. insert in cacheName
              cacheName[item->key]=item;
              //return value  
              return item;
          }finally{rwlock.DowngradeFromWriterLock(ref lk);}
       }
       finally{rwlock.ExitReadLock();}
    }
