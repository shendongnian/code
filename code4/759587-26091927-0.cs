    [WebGet]
    public IQueryable<Service> GetServicesByServiceName(string serviceNames)
    {
        var serviceNamesArray = serviceNames.Split(',');
        var ctx = YourContext();
        return ctx.Services.Include("ServiceQueryExpansion").Where(s => serviceNamesArrays.Any(n => s.ServiceName.Equals(n, StringComparison.OrdinalIgnoreCase))).AsQueryable();
    }
