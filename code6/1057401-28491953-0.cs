    public class ThumbnailProvider : IItemsProvider<ThumbnailItem>
    {
        private readonly int _itemsCount;
        public ThumbnailProvider(int itemsCount)
        {
            _itemsCount = itemsCount;
        }
        public int FetchCount()
        {
            return _itemsCount;
        }
        public IList<ThumbnailItem> FetchRange(int startIndex, int count)
        {
            var items = new List<ThumbnailItem>();
            while (count-- > 0)
            {
                items.Add(new ThumbnailItem()
                {
                    ImageUri = new Uri("ms-appx:///Assets/Square71x71Logo.scale-240.png")
                });
            }
            return items;
        }
    }
