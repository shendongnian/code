     public class MyConstructor
        {
            public void Do()
            {
                MemoryCacheManager.Instance.myObject.ToString();
            }
        }
    
        public class MemoryCacheManager
        {
            private MemoryCacheManager()
            {
                myObject = new object();
            }
    
            private static MemoryCacheManager _cacheManager;
    
            public static MemoryCacheManager Instance
            {
                get
                {
                    if(_cacheManager==null)
                        _cacheManager=new MemoryCacheManager();
                    return _cacheManager;
                }
            }
    
            public object myObject { get; private set; }
    
        }
