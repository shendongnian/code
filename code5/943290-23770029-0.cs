    var workflowRegistrationCache = new MemoryCache("workflow");
    container.Register<IWorkflowRegistrationService>(
        () => new WorkflowRegistrationService(workflowRegistrationCache));
    var migrationRegistrationCache = new MemoryCache("migration");
    container.Register<IMigrationRegistrationService>(
        () => new MigrationRegistrationService(migrationRegistrationCache));
