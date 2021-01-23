    var destinationOptions = new DeploymentBaseOptions()
    {
        // userName from Azure Websites PublishSettings file
        UserName = "$msdeploytest",
        // pw from PublishSettings file
        Password = "ThisIsNotMyPassword",
        // publishUrl from PublishSettings file using https: protocol prefix rather than 443 port
        // and adding "/msdeploy.axd?site={msdeploySite-variable-from-PublishSettings}"
        ComputerName = "https://waws-prod-blu-003.publish.azurewebsites.windows.net/msdeploy.axd?site=msdeploytest",
        AuthenticationType = "Basic"
    };
                                                                 // This option says we're giving it a directory to deploy
    using (var deploymentObject = DeploymentManager.CreateObject(DeploymentWellKnownProvider.ContentPath,
                                                                 // path to root directory of source files 
                                                                 @"C:\Users\ryan_000\Downloads\dummysite"))
    {
        var syncOptions = new DeploymentSyncOptions();
        syncOptions.WhatIf = false;
                                                                                       // "msdeploySite" variable from PublishSettings file
        var changes = deploymentObject.SyncTo(DeploymentWellKnownProvider.ContentPath, "msdeploytest", destinationOptions, syncOptions);
        Console.WriteLine("BytesCopied:       " + changes.BytesCopied.ToString());
        Console.WriteLine("Added:             " + changes.ObjectsAdded.ToString());
        Console.WriteLine("Updated:           " + changes.ObjectsUpdated.ToString());
        Console.WriteLine("Deleted:           " + changes.ObjectsDeleted.ToString());
        Console.WriteLine("Errors:            " + changes.Errors.ToString());
        Console.WriteLine("Warnings:          " + changes.Warnings.ToString());
        Console.WriteLine("ParametersChanged: " + changes.ParameterChanges.ToString());
        Console.WriteLine("TotalChanges:      " + changes.TotalChanges.ToString());
    }
