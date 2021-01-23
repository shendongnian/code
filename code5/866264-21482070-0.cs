    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    
    namespace CachingDemo
    {
        class CachedMemory
        {
            System.Collections.Specialized.OrderedDictionary cache = null;
            private String persistenceFilePath = null;
            private int cacheSizeLimit;
            public static readonly int CACHE_SIZE_NO_LIMIT = -1;
    
            public CachedMemory(int initialCapacity, int cacheSizeLimit, string persistenceFilePath)
            {
    
                this.cache = new System.Collections.Specialized.OrderedDictionary(initialCapacity);
                this.persistenceFilePath = persistenceFilePath;
                this.cacheSizeLimit = cacheSizeLimit;
    
            }
    
            public int getCacheSize()
            {
                return this.cache.Count;
            }
    
            public CachedMemory(int cacheSizeLimit, string cacheFilePath)
            {
                initializeCache(cacheFilePath, cacheSizeLimit);
            }
    
            private void initializeCache(string cacheFilePath, int cacheSizeLimit)
            {
                this.cacheSizeLimit = cacheSizeLimit;
                using (FileStream fileStream = new FileStream(cacheFilePath, FileMode.Open))
                {
                    IFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    this.cache = (System.Collections.Specialized.OrderedDictionary)bf.Deserialize(fileStream);
                    fileStream.Close();
                }
    
                //In case the deserialized OrderedDictionary had more contents than the limit, we need to shrink it to make its size equal to the limit
                if (this.cacheSizeLimit != CACHE_SIZE_NO_LIMIT && this.cache.Keys.Count > this.cacheSizeLimit)
                {
                    int difference = this.cache.Keys.Count - this.cacheSizeLimit;
    
                    for (int i = 0; i < difference; i++)
                    {
                        cache.RemoveAt(0);
                    }
                }
            }
    
            public string get(string key)
            {
                return cache[key] as string;
            }
    
            public string get(int index)
            {
                return cache[index] as string;
            }
    
    
            public void add(string key, string value)
            {
                //An ordered dictionary would throw an exception if we try to insert the same key again, so we have to make sure that the newly
                //introduced key is not a duplicate.
                if (this.cache.Contains(key))
                {
                    this.cache.Remove(key);
    
                }
                else
                    if (this.cacheSizeLimit != CACHE_SIZE_NO_LIMIT && this.cache.Count == this.cacheSizeLimit)
                    {
                        this.cache.RemoveAt(0);
    
                    }
    
                this.cache.Add(key, value);
            }
    
            public void persist()
            {
                using (FileStream fileStream = new FileStream(persistenceFilePath, FileMode.Create))
                {
                    IFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    bf.Serialize(fileStream, this.cache);
                    fileStream.Close();
                }
            }
        }
    }
