    public Task<List<TAzureTableEntity>> GetByPartitionKey(string partitionKey)
    {
        return Task.Run(() => table.CreateQuery<TAzureTableEntity>()
                                   .Where(ent => ent.PartitionKey == partitionKey)
                                   .ToList());
    }
