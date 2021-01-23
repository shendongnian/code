        Func<Task<List<MyData>>> cacheableAsyncFunc = () => myDataAccessObject.GetDataAsync();
    
        var cachedData = await cache.GetOrAddAsync("myDataAccessObject.GetData", cacheableAsyncFunc);
    
        return cachedData;
    
        // Or instead just do it all in one line if you prefer
        // return await cache.GetOrAddAsync("myDataAccessObject.GetData", myDataAccessObject.GetDataAsync);
    }
