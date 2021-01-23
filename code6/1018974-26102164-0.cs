         public class SchedularHandler
            {
                
                private static IScheduler _scheduler;
        
                public IScheduler Scheduler
                {
                    get
                    {
                        if (_scheduler == null)
                            _scheduler = GetScheduler();
                        return _scheduler;
                    }
        
                }
                public SchedularHandler()
                {
        
                    if (_scheduler == null)
                        _scheduler = GetScheduler();
        
                    if (!_scheduler.IsStarted)
                        _scheduler.Start();
                }
                private NameValueCollection GetProperties()
                {
                    NameValueCollection properties = new NameValueCollection();
                   properties["quartz.scheduler.instanceName"] = "RemoteClient";
                   properties["quartz.scheduler.instanceId"] = "AUTO";
                   // set thread pool info
                    properties["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool,Quartz";
                   properties["quartz.threadPool.threadCount"] = "5";
                  properties["quartz.threadPool.threadPriority"] = "Normal";
        
                  // set remoting expoter
                  properties["quartz.scheduler.proxy"] = "true";
                  properties["quartz.scheduler.proxy.address"] = "tcp://10.0.0.46:555/QuartzScheduler";
                    // First we must get a reference to a scheduler
                  return properties;
        
                }
                private IScheduler GetScheduler()
                {
                    
                    var properties = GetProperties();
                    var sf = new StdSchedulerFactory(properties);
                    return sf.GetScheduler();
                    
                }
          public DateTimeOffset ScheduleJob(IJobDetail jobDetail, ITrigger trigger)
            {
                return _scheduler.ScheduleJob(jobDetail, trigger);
            }
        
            }
