    private static ConcurrentDictionary<string, string> _tenantCache = new ConcurrentDictionary<string, string>();
    protected virtual void Application_BeginRequest(object sender, EventArgs e)
    {
        HttpApplication app = (HttpApplication)source;
        var tenantId = _tenantCache.GetOrAdd(app.Context.Request.Url.Host, host =>
                {
                   // Make database call in this class
                    var tenant = new TenantResolver();
                    return tenant.GetTenantId(host);
                })
        app.Context.Items["TenantID"] = tenantId ;
    }
