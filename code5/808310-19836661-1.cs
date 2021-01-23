    public static class IsolatedStorageManager
    {
        private static IsolateStorageStore IsolateStorageStore = new IsolateStorageStore();
        public static ItemViewModel FeedItemViewModel
        {
            get
            {
                return IsolateStorageStore.ReadValue<ItemViewModel>("ItemFeedsKey");
            }
            set
            {
                IsolateStorageStore.WriteValue("ItemFeedsKey", value);
            }
        }
        public static object AnotherItem
        {
            get
            {
                return IsolateStorageStore.ReadValue<object>("AnotherItemKey");
            }
            set
            {
                IsolateStorageStore.WriteValue("AnotherItemKey", value);
            }
        }
    }
