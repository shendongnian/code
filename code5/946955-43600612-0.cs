    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddIniFile("someotherfile.ini", false, true);
    
    var config = builder.Build();
    
    var quartzProperties = new System.Collections.Specialized.NameValueCollection();
    foreach (var p in config.GetSection("Quartz").GetChildren().AsEnumerable())
    {
        quartzProperties.Add(p.Key, p.Value);
    }
    
    IScheduler scheduler = new StdSchedulerFactory(quartzProperties).GetScheduler();
    scheduler.Start();
