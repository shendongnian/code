    using CompositionRoot; 
    ...
    ...
    
    private static void RegisterServices(IKernel kernel)
            {
                var cr = new MyExternalComposer(kernel);
                cr.DoBindings();
            }  
