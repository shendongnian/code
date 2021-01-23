    Pipeline pipeline = runspace.CreatePipeline();
    
    Command command = new Command("Set-CASMailbox");
    command.Parameters.Add("Identity", username);
    command.Parameters.Add("ActiveSyncAllowedDeviceIDs", "\"BLOCKED\"");
    pipeline.Commands.Add(command);
    
    //Run first cmdlet
    Collection<PSObject> result = pipeline.Invoke();
    
    //Not sure how to reset. Create new pipeline?
    //Pipeline pipeline = runspace.CreatePipeline();
    
    command = new Command("Set-CASMailbox");
    command.Parameters.Add("Identity", username);
    command.Parameters.Add("ActiveSyncEnabled", false);
    pipeline.Commands.Add(command);
    
    //Run second cmdlet
    Collection<PSObject> result = pipeline.Invoke();
