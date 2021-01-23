    public TypeLists GetTypeList()
    {
        if(_typeLists == null || DateTime.Now - _typeListAge > MaxCacheAge)
        {
            using(var dbContext = GetContext())
            {
                _typeLists = GetNewTypeList(Context dbContext);
            }
        }
    
        return _typeLists;
    }
    
    private TypeLists GetNewTypeList(Context dbContext)
    {
        var container = new TypeLists()
    
        container.CustomerTypes = dbContext.GetCustomerTypes();
        container.FormatTypes = dbContext.GetFormatTypes();
        container.WidgetTypes = dbContext.GetFormatTypes();
        container.PriceList = dbContext.GetPriceList ();
        
        return container;
    }
