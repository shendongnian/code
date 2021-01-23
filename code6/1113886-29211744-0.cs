    public void Configuration(IAppBuilder app)
    {
        app.UseHangfire(config =>
        {
            config.UseSqlServerStorage("connection string");
            config.UseServer();
        });
       InitializeJobs();
    }
    public static void InitializeJobs()
    {            
    	RecurringJob.AddOrUpdate("jobName", () => CallToJobFunction(), Cron.Minutely);
    }
