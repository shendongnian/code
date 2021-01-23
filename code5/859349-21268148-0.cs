    public async List<string> ProcessDocument()
    {
      Document someDocument = await db.GetDocumentAsync(documentId);
      //Parse will not be called until GetDocumentAsync completes and result is available.
      //Thus it appears to "block", it is not technically blocking, 
      //  as a caller of ProcessDocument can start an async call to ProcessDocument 
      //  and perform other parallel processing while GetDocumentAsync is processing,
      //  because ProcessDocument is marked async
      return Parse(someDocument.Contents);
    }
    
    public void ApplicationStart() {
        
        //no await when calling async method, processing begins asynchrounously
        Task<List<string>> parseDocTask = ProcessDocument("http://msdn.microsoft.com");
    
        //we will continue other work while ProcessDocument is asynchronously performing work
        //We can execute DoIndependentWork while at the same time ProcessDocument is working on a separate thread asynchronously
        DoIndependentWork();
    
        //get result of async call, either will block until result is available,
        // or if async ProcessDocument task has already completed, will continue immediately
        List<string> parsedDocument = await parseDocTask;
    
        //do something with parsedDocument
    }
