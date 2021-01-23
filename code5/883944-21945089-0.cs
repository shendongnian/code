    Class CacheContainer
    {
        List<CustomerTypes> CustomerTypes {get; set;}
        List<FormatTypes> FormatTypes {get; set;}
        List<WidgetTypes> WidgetTypes {get; set}
        List<PriceList> PriceList {get; set;}
    }
    
    
    //In the class the below code resides in replace the 
    // 4 properties with a single property 
    // CacheContainer CachedTypes {get; set;}
    
    // Update the references
    var container = new CacheContainer()
    
    container.CustomerTypes = customerTypes;
    container.FormatTypes = formatTypes;
    container.WidgetTypes = widgetTypes;
    container.PriceList = priceList;
    
    CachedTypes = container;
