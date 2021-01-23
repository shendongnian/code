    internal static class Cache<T>
       {
          public static void Save(IList<T> list, int insertAt, string cacheKey)
          {
             // Cache key per Session
             cacheKey = HttpContext.Current.Session.SessionID + "~" + cacheKey; 
    
             if (list != null && list.Count > 0)
             {
                // if list is already there, insert items in list.
                IList<T> cachedList = HttpContext.Current.Cache[cacheKey] as IList<T>;
                if (cachedList != null)
                {
                   // remove list from cache.
                   HttpContext.Current.Cache.Remove(cacheKey);
    
                   // insert items at position.
                   if (insertAt < 0)
                   {
                      insertAt = cachedList.Count;
                   }
                   foreach (T item in list)
                   {
                      cachedList.Insert(insertAt, item);
                      insertAt++;
                   }
                }
                else
                {
                   // check that list is no array, because that cannot be removed.
                   cachedList = list.GetType().IsArray ? new List<T>(list) : list;
                }
    
                // save list in cache for 30 seconds.
                HttpContext.Current.Cache.Insert(
                                                cacheKey
                                              , cachedList
                                              , null
                                              , DateTime.Now.AddSeconds(30)
                                              , Cache.NoSlidingExpiration
                                                );
             }
          }
    
          public static void Save(IList<T> list, string cacheKey)
          {
             Save(list, -1, cacheKey);
          }
          public static void Save(IList<T> list, int insertAt)
          {
             Save(list, insertAt, typeof(T).Name);
          }
    
          public static int Remove(T item, string cacheKey)
          {
             // index of removed item.
             int removedIndex = -1;
             // cache key per Session
             cacheKey = HttpContext.Current.Session.SessionID + "~" + cacheKey; 
    
             if (item != null)
             {
                // remove from  cache.
                IList<T> cachedList = HttpContext.Current.Cache[cacheKey] as IList<T>;
                if (cachedList != null)
                {
                   // remove list from cache.
                   HttpContext.Current.Cache.Remove(cacheKey);
    
                   // remove item from cached list..
                   removedIndex = cachedList.IndexOf(item);
                   cachedList.Remove(item);
    
                   // insert list for 30 sec.
                   HttpContext.Current.Cache.Insert(
                                                   cacheKey
                                                 , cachedList
                                                 , null
                                                 , DateTime.Now.AddSeconds(30)
                                                 , Cache.NoSlidingExpiration
                                                   );
                }
             }
             return removedIndex;
          }
    
          public static int Remove(T item)
          {
             return Remove(item, typeof(T).Name);
          }
    
          public static void Clear(string cacheKey)
          {
             // cache Key per Session
             cacheKey = HttpContext.Current.Session.SessionID + "~" + cacheKey;
             
             HttpContext.Current.Cache.Remove(cacheKey);
          }
    
          public static void Clear()
          {
             Clear(typeof(T).Name);
          }
    
    }
