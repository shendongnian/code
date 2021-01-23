    // Load the XAMLX workflow service.
    WorkflowService workflow1 =
        (WorkflowService)XamlServices.Load(xamlxPath);
    
    // Compile the C# expressions in the workflow by passing the Body to CompileExpressions.
    CompileExpressions(workflow1.Body);
    
    // Initialize the WorkflowServiceHost.
    var host = new WorkflowServiceHost(workflow1, new Uri("http://localhost:8293/Service1.xamlx"));
    
    // Enable Metadata publishing/
    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
    smb.HttpGetEnabled = true;
    smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
    host.Description.Behaviors.Add(smb);
    
    // Open the WorkflowServiceHost and wait for requests.
    host.Open();
    Console.WriteLine("Press enter to quit");
    Console.ReadLine();
