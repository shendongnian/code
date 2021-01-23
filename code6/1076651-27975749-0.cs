    WorkflowDbContext db = new WorkflowDbContext();
    var workflowFromDb = db.Workflows.Find("1");
    ActivityXamlServicesSettings activitySettings = new ActivityXamlServicesSettings
    {
        CompileExpressions = true
    };
    XamlXmlReaderSettings xamlReaderSettings = new XamlXmlReaderSettings { LocalAssembly = typeof(GetTouchPoint).Assembly };
    XamlReader xamlReader = new XamlXmlReader(new StringReader(workflowFromDb.WorkflowDefinition), xamlReaderSettings);
    var wf = ActivityXamlServices.Load(xamlReader, activitySettings);
    var result = WorkflowInvoker.Invoke(wf);
