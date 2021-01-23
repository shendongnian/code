    private object itemsLock = new object();
    private DateTime? lastQuery = new DateTime();
    private List<Item> items;
    public List<Item> Items
    {
        get
        {
            DateTime lastPublication = ComputeLastPublicationDate();
            if (items != null && lastQuery >= lastPublication)
                return items;
            lock (itemsLock)
            {
                // lock double check
                if (items != null && lastQuery >= lastPublication)
                    return items;
                // not yet retrieved locally 
                if (items == null)  
                {
                    items = GetListFromLocalStorage(out lastQuery);
                }
                if (item == null || lastQuery < lastPublication)
                {
                    items = GetListFromWebService();
                    lastQuery = DateTime.Now;
                    StoreListToLocalStorage(items, lastQuery);
                }
                return items;
            }
        }
    }
