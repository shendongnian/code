    This simple change will likely do the job:
 
        public INotBaseClassFunctionsProvider : Interface
        {
            INotBaseClassFunctions GetSubclass();
        } 
    > NOTE: It's up to you how you define that way the underlying type is provided, we generally only use properties in a class if the subclass object is persisted in the provider object, for factories and other interfaces I like to use methods to expose the subclass object because I don't have control over the actual implementation or whether the object will be persisted or not.
    > > When you use methods the caller *must* infer that getting the object is a process in itself that may take time or throw errors. 
        public INotBaseClassFunctions SubFunctions<T>() where T : INotBaseClassFunctionsProvider, new()
        {
           var provider = new T();
           return provider.GetSubClass(); 
        }
