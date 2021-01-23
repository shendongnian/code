    // create a workspace on my production server
    try
    {
        wSpace = vcsProdServer.GetWorkspace(cWsMapping, vcsProdServer.AuthorizedUser);
    }
    catch
    {
        wSpace = vcsProdServer.CreateWorkspace(cWsMapping);
        wSpace.Map(pProjectName, combinedPath);
    }
    wSpace.Get();
