    Parallel.ForEach(fileList, 
                     () => CreateClientContext(storeUrl), //This function creates a new context for the specified url. 
                     (currentfileItem, loopState, localContext) =>
    {
        localContext.Load(currentfileItem, w => w.File);
        localContext.ExecuteQuery();
    
        if (currentfileItem.File == null)
        {
            throw new Exception(
                String.Format("File information not found for the item {0}",
                    currentfileItem.DisplayName));
        }
    
        var currentFileName = currentfileItem.File.Name;
    
    
    
        if (!string.IsNullOrEmpty(docRevVersionId))
        {
            var info = Microsoft.SharePoint.Client.File.OpenBinaryDirect(
                localContext, currentfileItem["fRef"].ToString());
            if (info != null)
            {
                UpdateToServer(Id, currentFileName, info.Stream);
            }
        }
    
        return localContext;
    },
                  (localContext) => localContext.Dispose()); //Dispose the thread local context
    
    //Elsewhere
    private static ClientContext CreateClientContext(string url)
    {
        ClientContext context = new ClientContext(url);
        //Perform any additional setup you need on the context here.
        //If you don't need any you could just replace "CreateClientContext(storeUrl)"
        //with "new ClientContext(storeUrl)" up at the ForEach declaration.
        return context;
    }
