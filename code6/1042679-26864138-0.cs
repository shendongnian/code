    public class InjectorJobFactory : IJobFactory
    {
        private readonly ILifetimeScope _lifetimeScope;
        public InjectorJobFactory(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            MethodInfo method = GetType().GetMethod("GetJob", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo generic = method.MakeGenericMethod(bundle.JobDetail.JobType);
            return (IJob)generic.Invoke(this, null);
        }
        private IJob GetJob<T>() where T : IJob
        {
            return _lifetimeScope.Resolve<JobWrapper<T>>();
        }
        public void ReturnJob(IJob job)
        {
            
        }
    }
