    class IncrementalLoadingObservableCollection<T> : ObservableCollection<T>, ISupportIncrementalLoading
    {
        private readonly Func<CancellationToken, Task<IEnumerable<T>>> _provideMoreItems;
        public IncrementalLoadingObservableCollection(Func<CancellationToken, Task<IEnumerable<T>> provideMoreItems)
        {
            _provideMoreItems = provideMoreItems;
        }
        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            return AsyncInfo.Run(async cancelToken =>
            {
                await Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    await OnLoadMoreItemsStarted();
                });
                var providedItems = await _provideMoreItems(cancelToken);
                await Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    foreach(var item in providedItems)
                        Add(item);
                    await OnLoadMoreItemsCompleted();
                });
                return new LoadMoreItemsResult {Count = (uint) providedItems.Count()};;
            });
        }
        public bool HasMoreItems
        {
            get { return true; }
        }
        public event Func<Task> LoadMoreItemsStarted;
        public event Func<Task> LoadMoreItemsCompleted;
        protected virtual void OnLoadMoreItemsStarted()
        {
            var handler = LoadMoreItemsStarted;
            if (handler != null) handler();
        }
        protected virtual void OnLoadMoreItemsCompleted()
        {
            var handler = LoadMoreItemsCompleted;
            if (handler != null) handler();
        }
    }
