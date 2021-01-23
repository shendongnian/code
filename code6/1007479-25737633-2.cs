    public async Task MainProcess()
    {
        var batches = emailsToProcess.Batch(CONST_BATCHES_SIZE);
    
        foreach (var batch in batches)
        {
             return batch.ForEachAsync(batch.Count, async (m) =>
             {
                 await ProcessSingleEmail(m);                
             });
           _emailsToProcessRepository.MarkBatchAsProcessed(batch);             
        }
    }
