    async Task<Model> GetModelAsync()
    {
      ModelAsync = TaskEx.Run(...);
      await ModelAsync;
      // ModelAsync.IsCompleted is true here.
    }
