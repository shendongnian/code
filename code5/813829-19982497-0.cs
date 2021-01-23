    Parallel.ForEach(fileList, 
                     CreateClientContext, //This function creates a new context. 
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
    private static ClientContext CreateClientContext()
    {
        ClientContext context;
        //...Magic...
        return context;
    }
