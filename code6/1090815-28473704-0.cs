    public async Task IndexManyAsync(IEnumerable<IIndexModel> indexModels) 
    {
        var client = new ElasticClient(settings);
    
        var taskBatches = indexModels.Batch(1000)
                                     .Select(partition =>
                                             client.IndexManyAsync(partition)).ToArray();
    
        await Task.WhenAll(taskBatches);
    }
