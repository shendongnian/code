    /// <summary>
    /// The logging module.
    /// </summary>
    public class LoggingModule : Module
    {
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        /// <param name="builder">The builder through which components can be registered.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NewLogger>()
                .As<ILogger>()
                .WithParameter(new NamedParameter("category", "Default"));
            base.Load(builder);
        }
        /// <summary>
        /// Override to attach module-specific functionality to a component registration.
        /// </summary>
        /// <remarks>
        /// This method will be called for all existing <i>and future</i> component
        /// registrations - ordering is not important.
        /// </remarks>
        /// <param name="componentRegistry">The component registry.</param><param name="registration">The registration to attach functionality to.</param>
        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            registration.Preparing += (sender, args) =>
                {
                    var type = args.Component.Activator.LimitType;
                    if (type.GetInterfaces().All(_ => !_.IsGenericType || _.GetGenericTypeDefinition() != typeof(IRepository<>)))
                        return;
                    
                    var pm = new ResolvedParameter(
                        (p, c) => p.ParameterType == typeof(ILogger),
                        (p, c) => c.Resolve<ILogger>(new NamedParameter("category", "RepositoryLogger")));
                    args.Parameters = args.Parameters.Union(new[] { pm });
                };
            base.AttachToComponentRegistration(componentRegistry, registration);
        }
    }
