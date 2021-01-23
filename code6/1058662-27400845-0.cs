    private static void RegisterServices(IKernel kernel)
    {
        DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        ...
    }
