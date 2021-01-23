    public static class ObjectFactory
    {
        public static IKernel Kernel { get; internal set; }
        public T GetInstance<T>()
        {
            return Kernel.Get<T>();
        }
    }
    // somewhere initialization of static instance needs to be done:
    ObjectFactory.Kernel = new StandardKernel();
