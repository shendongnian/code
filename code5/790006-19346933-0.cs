    public Task SearchAsync()
    {
      var subsets = CreateSubsets(originalList);
     return Task.WhenAll(subsets.Select(subset => SearchSubsetAsync(subset)));
    }
    private Task SearchSubsetAsync(List<SearchCriteria> subset)
    {
      var semaphore = new SemaphoreSlim(3);
      return Task.WhenAll(subset.Select(criteria => SearchCriteriaAsync(criteria, semaphore)));
    }
    private async Task SearchCriteriaAsync(SearchCriteria criteria, SemaphoreSlim semaphore)
    {
      await semaphore.WaitAsync();
      try
      {
        // SearchForCriteriaAsync uses HttpClient (async).
        var results = await SearchForCriteriaAsync(criteria);
        // Consider returning results rather than processing them here.
      }
      finally
      {
        semaphore.Release();
      }
    }
