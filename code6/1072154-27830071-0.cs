    static const int batchSize = 100;
    public async Task<IEnumerable<Results>> GetDataInBatches(IEnumerable<RequestParameters> parameters) {
        if(!parameters.Any())
            return Enumerable.Empty<Result>();
        var batchResults = await Task.WhenAll(parameters.Take(batchSize).Select(doQuery));
        return batchResults.Concat(await GetDataInBatches(parameters.Skip(batchSize));        
    }
