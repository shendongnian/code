    public async Task<IEnumerable<T>> Query<T>(string databaseId, string collectionId, SqlQuerySpec sqlQuery, int take)
	where T : Resource
    {
        double queryCost = 0;
        const int maxPageSize = 100;
        
        var query = _client.CreateDocumentQuery<T>(
        	UriFactory.CreateDocumentCollectionUri(databaseId, collectionId),
        	sqlQuery,
        	new FeedOptions() {MaxItemCount = Math.Min(maxPageSize, take)}).AsDocumentQuery();
        
        var response = await query.ExecuteNextAsync<T>();
        queryCost += response.RequestCharge;
        var entities = response.ToList();
        
        while (entities.Count < take && query.HasMoreResults)
        {
        	var nextResponse = await query.ExecuteNextAsync<T>();
        	queryCost += nextResponse.RequestCharge;
        	entities.AddRange(nextResponse);
        }
        
        Debug.WriteLine(
        	"Query [{0}] for {1} documents in collection [{2}] cost {3} RUs.",
        	sqlQuery.QueryText,
        	take,
        	collectionId,
        	queryCost);
        
        return entities.Take(take).ToList(); // We may end up with more than the requested number of items.
    }
