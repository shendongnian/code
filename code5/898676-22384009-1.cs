    var defRunspace = System.Management.Automation.Runspaces.Runspace.DefaultRunspace;
    var pipeline = defRunspace.CreateNestedPipeline();
    pipeline.Commands.AddScript("$vm1,$vm2,$vm3,$vm4");
    var results = pipeline.Invoke();
    var vm1 = results[0];
    var vm2 = results[1];
    ...
