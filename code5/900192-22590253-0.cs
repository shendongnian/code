    public class HJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            using (var container = CustomDependencyResolver.Container.BeginLifetimeScope(
                builder => builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().As<IRepositoryFactory>().InstancePerLifetimeScope()
                ))
            {
                
            }
        }
    }
