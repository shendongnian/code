    public Task<Document> GetDocumentAsync(string docId)
    {
        var docClient = CreateDocumentServiceClient();
        using (new OperationContextScope(docClient.InnerChannel))
        {
            var task = docClient.GetDocumentAsync(docId);
        }
        return await task;
    }
