    IUnityContainer container = new UnityContainer();
    
    // Default registration if required
    container.RegisterType<IWorkflowModule, StartView>();
    
    // IEnumerable Registration 
    container.RegisterType<IWorkflowModule, StartView>("WorkflowConfigReaderItem1");
    container.RegisterType<IWorkflowModule, EndView>("WorkflowConfigReaderItem2");
    container.RegisterType<List<IWorkflowModule>>(new InjectionFactory(c =>
        {
            return c.ResolveAll<IWorkflowModule>().ToList();
        }));
