    public class CacheData
    {
        private static object _readLock = new object();
        private static object _writeLock = new object();
        public SPListItemCollection ListItem
        {
            get
            {
                var oListItems = (SPListItemCollection) Cache["ListItemCacheName"];
                if (oListItems == null)
                {
                    lock (_readLock)
                    {
                        oListItems = (SPListItemCollection)Cache["ListItemCacheName"];
                        if (oListItems == null)
                        {
                            oListItems = DoQueryToReturnItems();
                            Cache.Add("ListItemCacheName", oListItems, ..);
                        }
                    }
                }
                return oListItems;
            }
            set
            {
                lock (_writeLock)
                {
                    Cache.Add("ListItemCacheName", value, ..);
                }
            }
        }
        public void Refresh()
        {
            lock (_readLock)
            {
                Cache.Remove("ListItemCacheName");
                var oListItems = DoQueryToReturnItems();
                ListItem = oListItems;                
            }
        }
    }
