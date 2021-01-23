    public DataSourceResult GetCustomer(Kendo.Mvc.UI.DataSourceRequest request)
    {
        return new DataLayer.MainDataContext().Customer()
            .Where(x => x.IsActive)
            .ToDataSourceResult(request);
    }
