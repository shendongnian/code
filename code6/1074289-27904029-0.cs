    public IList<Kendo.Mvc.IFilterDescriptor> GetFilters()
    {
        List<Kendo.Mvc.FilterDescriptor> filters = new List<Kendo.Mvc.FiterDescriptor>();
    
        filters.Add(new Kendo.Mvc.FilterDescriptor("Column", Kendo.Mvc.FilterOperator.Contains, "1"));
    
        IList<Kendo.Mvc.IFilterDescriptor>() iFilters = new List<Kendo.Mvc.IFilterDescriptor>();
    
        foreach(var filter in filters)
        {
           Kendo.Mvc.IFilterDescriptor temp = null;
           temp = filter;
           
           if(temp is Kendo.Mvc.FilterDescriptor)
           {
               iFilters.Add(temp);
           }
        }
    
        return filters;
    }
