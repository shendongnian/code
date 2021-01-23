     public class JobFactoryInjection : IJobFactory
    {
        
            private readonly UnityContainer container = new UnityContainer(); 
            public JobFactoryInjection(UnityContainer container)
            {
               
                if (container == null) throw new ArgumentNullException("container", "Container is null");
                this.container = container;
            }
        
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler) {
           
               
                // Return job registrated in container
                bundle.JobDetail.JobDataMap.Put(SyncUtils.ContextKeyCenterCode, scheduler.Context.Get(SyncUtils.ContextKeyCenterCode));
                return (IJob)container.Resolve(bundle.JobDetail.JobType);
          
        }
        public void ReturnJob(IJob job) {
            
        }
    }
