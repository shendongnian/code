    ProcessingPipeline.ProcessedRequest += ProcessingPipeline_ProcessedRequest;
    
    void ProcessingPipeline_ProcessedRequest(object sender, DataServiceProcessingPipelineEventArgs e)
    {
        int statusCode = e.OperationContext.ResponseStatusCode;
    }
