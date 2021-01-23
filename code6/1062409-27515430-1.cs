    Pipeline pipeline = runspace.CreatePipeline();
    
    Command command = new Command("Set-CASMailbox");
    command.Parameters.Add("Identity", username);
    command.Parameters.Add("ActiveSyncAllowedDeviceIDs", "BLOCKED");
    pipeline.Commands.Add(command);
    
    //Run first cmdlet
    Collection<PSObject> result = pipeline.Invoke();
    
    //Not sure how to reset. Create new pipeline?
    Pipeline pipeline2 = runspace.CreatePipeline();
    
    Command command2 = new Command("Set-CASMailbox");
    command2.Parameters.Add("Identity", username);
    command2.Parameters.Add("ActiveSyncEnabled", false);
    pipeline2.Commands.Add(command);
    
    //Run second cmdlet
    Collection<PSObject> result2 = pipeline2.Invoke();
