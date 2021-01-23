    [Dependency("alarmsService")]
    public IAlarmsService AlarmsService { get; set; }
    
    [Dependency("jsonFactory")]
    public IJSONFactoryService JsonFactory { get; set; }
    
    [Dependency("dataBean")]
    public IDataBean DataBean { get; set; } 
