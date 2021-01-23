    public TypeLists GetTypeList()
    {
        if(_typeLists == null || DateTime.Now - _typeListAge > MaxCacheAge)
        {
            //Multiple threads could call this function at the same time with 
            //the current implementation, however class assignment is thread 
            //safe so there is no problem. Lock in this section if you don't 
            //want that to happen.
            _typeLists = GetNewTypeList();
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
