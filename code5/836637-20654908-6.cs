    using Unity.Web;
    
    public LogWriter getLogWriter()
    {
        var container = HttpContext.Current.Application.GetContainer();
        return container.Resolve<LogWriter>();
    }
