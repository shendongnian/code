    AppSettings result = null;
    
    lock (thisLock)
    {
        if (cache[filename] != null) {
            result = (AppSettings)cache[filename];
        }
        else
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                instance = (AppSettings)serial.Deserialize(sr);
                cache.Insert(filename, instance, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration);
            }
    
            result = (AppSettings)cache[filename];
        }
    }
    
    return result;
