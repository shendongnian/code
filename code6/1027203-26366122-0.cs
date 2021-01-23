     MemoryCache.Default.Add(FileName, FileName, new CacheItemPolicy
                    {
                        SlidingExpiration = new TimeSpan(0, 60, 0), // 60 minutes
                        RemovedCallback = RemoveFileFromCacheCallback
                    });
     private void RemoveFileFromCacheCallback(CacheEntryRemovedArguments args)
     {
         var fileName = args.CacheItem.Key;
         var fullFileName = Path.Combine(Path.GetTempPath(), fileName);
         if (File.Exists(fullFileName))
         {
             File.Delete(fullFileName);
         }
     }
