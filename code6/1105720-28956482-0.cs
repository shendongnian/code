    static MyConstructor()
                {
                    cacheDataManager = new MemoryCacheManager();
    
                    var timer = new System.Threading.Timer(
                               e => LoadMyCacheData(),
                              null,
                              TimeSpan.Zero,
                             TimeSpan.FromSeconds(30));
                }
