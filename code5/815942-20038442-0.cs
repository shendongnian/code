    private readonly IKernel _kernel;
    public IKernel CreateKernel() { // Ninject calls this after inheriting
                                    // from NinjectHttpApplication
        _kernel = Bootstrap.Init();
    
        return _kernel;
    }
