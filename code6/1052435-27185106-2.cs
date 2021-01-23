    private IScheduler scheduler;        
    private ISchedulerFactory schedulerFactory;
    NameValueCollection propColl = new NameValueCollection();
    propColl.Add("org.quartz.jobStore.misfireThreshold", "216000000");  // Amount of milliseconds that may pass till a trigger that couldn't start in time counts as misfired (216000000 ms => 1 hour) 
    propColl.Add("org.quartz.scheduler.batchTriggerAcquisitionFireAheadTimeWindow", "5"); // Trigger may fire up to 5 ms before scheduled starttime
    propColl.Add("quartz.threadPool.threadCount", "1"); // Allows only one Thread in parallel
    schedulerFactory = new StdSchedulerFactory(propColl);
    scheduler = schedulerFactory.GetScheduler();
    scheduler.Start();
