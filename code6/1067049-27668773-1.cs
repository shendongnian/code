    public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
    {
      return DoLoadMoreItemsAsync(count).AsAsyncOperation();
    }
    private async Task<LoadMoreItemsResult> DoLoadMoreItemsAsync(uint count)
    {
      var result = await func(++this.currentPage);
      if (result == null || result.Count == 0)
      {
        hasMoreItems = false;
      }
      else
      {
        foreach (T item in result)
          this.Add(item);
      }
      return new LoadMoreItemsResult() { Count = result == null ? 0 : result.Count };
    }
