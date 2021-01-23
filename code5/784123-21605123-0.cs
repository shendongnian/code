    interface DataService
    {
        IList<Items> GetList();
        void SetList(IList<Items> items);
    }
    class InMemoryDataService : DataService
    {
        public InMemoryDataService(DataService other)
        {
            Other = other;
        }
        public IList<Items> GetList()
        {
            if (!Items.Any())
            {
                Items = Other.GetList();
            }
            return Items;
        }
        public void SetList(IList<Items> items)
        {
            Items = items;
            Other.SetList(items);
        }
        private IList<Items> Items { get; set; }
        private DataService Other { get; set; }
    }
    class IsoStorageDataService : DataService
    {
        public IsoStorageDataService(DataService other)
        {
            Other = other;
        }
        public IList<Items> GetList()
        {
            ...
        }
        private DataService Other { get; set; }
    }
