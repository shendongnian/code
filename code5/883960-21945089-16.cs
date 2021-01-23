    private readonly object _typeListsLookupLock = new object();
    private volatile TypeLists _typeLists;
    private volatile DateTime _typeListAge;
    public TypeLists GetTypeList()
    {
        if(_typeLists == null || DateTime.UtcNow - _typeListAge > MaxCacheAge)
        {
            //The assignment of _typeLists is thread safe, this lock is only to 
            //prevent multiple concurrent database lookups. If you don't care that 
            //two threads could call GetNewTypeList() at the same time you can remove 
            //the lock and inner if check.
            lock(_typeListsLookupLock)
            {
                //Check to see if while we where waiting to enter the lock someone else 
                //updated the lists and making the call to the database unnecessary.
                if(_typeLists == null || DateTime.UtcNow - _typeListAge > MaxCacheAge)
                {
                    _typeLists = GetNewTypeList();
                    _typeListAge = DateTime.UtcNow;
                }
            }
        }
        return _typeLists;
    }
    
    private TypeLists GetNewTypeList()
    {
        var container = new TypeLists()
        using(var dbContext = GetContext())
        {
            container.CustomerTypes = dbContext.GetCustomerTypes();
            container.FormatTypes = dbContext.GetFormatTypes();
            container.WidgetTypes = dbContext.GetFormatTypes();
            container.PriceList = dbContext.GetPriceList ();
        }
        return container;
    }
