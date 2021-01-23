    var workflowRegistrationCache = new MemoryCache("workflow");
    var migrationRegistrationCache = new MemoryCache("migration");
    container.RegisterWithContext<MemoryCache>(context =>
    {
       return context.ServiceType == typeof(IWorkflowRegistrationService)
           ? workflowRegistrationCache 
           : migrationRegistrationCache;
    });
    container.Register<IWorkflowRegistrationService, WorkflowRegistrationService>();
    container.Register<IMigrationRegistrationService, MigrationRegistrationService>();
