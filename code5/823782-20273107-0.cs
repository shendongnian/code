    public Task<SwepubHeader[]> DoSearchAdvancedAsync(
        SwepubSearchServiceClient client,
        string query, string[] subQuerys,
        Dictionary<string, string> advancedSearchParameters)
    {
      return Task.WhenAll(subQuerys
          .Where(subQuery => !string.IsNullOrWhiteSpace(subQuery))
          .Select(subQuery => client.DoSwepubSearchAdvancedAsync(
              query, subQuery, advancedSearchParameters)));
    }
