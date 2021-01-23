    using System.Collections.Generic;
    using System.Collections.Concurrent;
    
    namespace MyApplication 
    {
        class FooMultiton 
        {
            private static readonly ConcurrentDictionary<object, FooMultiton> _instances
            = new ConcurrentDictionary<object, FooMultiton>();
 
            private FooMultiton() {}
 
            public static FooMultiton GetInstance(object key) 
            {
                _instances.TryAdd(key, new FooMultiton()); // This would of course be new MyLogger(_dbName)
                return _instances[key];
            }
        }
    }
