    public class InjectorJobFactory : IJobFactory
    {
        private readonly ILifetimeScope _lifetimeScope;
        public InjectorJobFactory(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            var type = typeof(JobWrapper<>).MakeGenericType(bundle.JobDetail.JobType);
            return (IJob)_lifetimeScope.Resolve(type);
        }
        public void ReturnJob(IJob job)
        {
            
        }
    }
