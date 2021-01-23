    class FooMultiton
    {
        private static readonly Dictionary<object, FooMultiton> _instances =
            new Dictionary<object, FooMultiton>();
 
        // this is the classic good old singleton trick (prevent direct instantiation)
        private FooMultiton()
        { }
 
        // you can also have private concrete implementations, 
        // invisible to the outside world
        private class ConcreteFooMultitonOne : FooMultiton
        { }
        public static FooMultiton GetInstance(object key)
        {
            lock (_instances) 
            {   
                FooMultiton instance;
                // if it doesn't exist, create it and store it
                if (!_instances.TryGetValue(key, out instance))
                {
                    // at this point, you can create a derived class instance
                    instance = new ConcreteFooMultitonOne();
                    _instances.Add(key, instance);
                }
                // always return the same ("singleton") instance for this key
                return instance;
            }
        }
    }
