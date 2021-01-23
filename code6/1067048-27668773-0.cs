    public class IncrementalCollection<T> : ObservableCollection<T>, ISupportIncrementalLoading
    {
      private bool hasMoreItems;
      private int currentPage;
      private Func<int, Task<IList<T>>> func;
      public IncrementalCollection(Func<int, Task<IList<T>>> func)
      {
        this.func = func;
        this.hasMoreItems = true;
      }
      public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
      {
        var dispatcher = Window.Current.Dispatcher;
        return Task.Run<LoadMoreItemsResult>(async () =>
        {
          uint resultCount = 0;
          var result = await func(++this.currentPage);
          if (result == null || result.Count == 0)
          {
            hasMoreItems = false;
          }
          else
          {
            resultCount = (uint)result.Count;
            await dispatcher.RunAsync(
                 CoreDispatcherPriority.Normal,
                 () =>
                 {
                   foreach (T item in result)
                     this.Add(item);
                 });
          }
          return new LoadMoreItemsResult() { Count = resultCount };
        }).AsAsyncOperation<LoadMoreItemsResult>();
      }
    }
