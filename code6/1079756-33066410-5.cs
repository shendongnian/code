    class VirtualList : ObservableCollection<string>, ISupportIncrementalLoading
    {
        private IReadOnlyList<StorageFile> photos;
        public VirtualList(IReadOnlyList<StorageFile> files) : base()
        {
            photos = files;
        }
        public bool HasMoreItems
        {
            get
            {
                return this.Count < photos.Count;
            }
        }
        public Windows.Foundation.IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            return LoadMoreItemsAwaitable(count).AsAsyncOperation<LoadMoreItemsResult>();
        }
        private async Task<LoadMoreItemsResult> LoadMoreItemsAwaitable(uint count)
        {
            int offset = this.Count;
            for (int i = offset; i < offset + count && i < photos.Count; i++)
            {
                this.Add(photos[i].Path);
            }
            return new LoadMoreItemsResult { Count = count };
        }
    }
