    public Windows.Foundation.IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
    {
	    if (count > 50 || count <= 0)
	    {
	        // default load count to be set to 50
	        count = 50;
	    }
	
    	return LoadMoreItemsTaskAsync(count)
			.AsAsyncOperation<LoadMoreItemsResult>();
    }
	private async Task<LoadMoreItemsResult> LoadMoreItemsTaskAsync(uint count)
	{
		var result = await ytSearcher.SearchVideos(Query, ++CurrentPage);
        result.ForEach(i => this.Add(i));
		return new LoadMoreItemsResult() { Count = (uint)result.Count };
	}
