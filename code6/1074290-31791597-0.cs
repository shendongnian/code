    public IList<Kendo.Mvc.IFilterDescriptor> GetFilters()
    {
        IList<Kendo.Mvc.IFilterDescriptor> filters = new List<Kendo.Mvc.IFilterDescriptor>();
        filters.Add(new Kendo.Mvc.FilterDescriptor("Column", Kendo.Mvc.FilterOperator.Contains, "1"));
        return filters;
    }
