    In this method (my preferred approach), you won't be calling `kernel.Inject(instance)` each time, only for the first time the singleton is initialized. Adding the following method to your `ConcreteSingleton` class:
    
        public static ConcreteSingleton GetInstance(IKernel kernelForInjection)
        {
            if (_instance.IsValueCreated == false)
            {
                kernelForInjection.Inject(_instance.Value);
            }
    
            return _instance.Value;
        }
    
    And using this binding:
    
        kernel.Bind<ISingleton>().ToMethod(c => ConcreteSingleton.GetInstance(c.Kernel));
    
    Will achieve the desired behavior of not having a public constructor but enabling your facade to be efficiently injected.
