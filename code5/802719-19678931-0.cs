    static void Main(string[] args)
    {
        var runSpace = RunspaceFactory.CreateRunspace();
        runSpace.Open();
        var pipeline = runSpace.CreatePipeline();
    
        runSpace.SessionStateProxy.SetVariable("item", "a");
        var a = runSpace.SessionStateProxy.PSVariable.GetValue("item");
        var variable = new Command("Write-Host $item");
    
        pipeline.Commands.Add(variable);
        pipeline.Invoke();
    
        Console.ReadLine();
    }
