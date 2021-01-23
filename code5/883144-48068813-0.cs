    public class NLoggerModule : Module
    {
        private readonly NLogLoggerProvider _provider;
        public NLoggerModule()
        {
            _provider = new NLogLoggerProvider();
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(CreateLogger).AsImplementedInterfaces();
        }
        private ILogger CreateLogger(IComponentContext c, IEnumerable<Parameter> p)
        {
            var logger = _provider.CreateLogger(p.TypedAs<Type>().FullName);
            return logger;
        }
        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            registration.Preparing += Registration_Preparing;
        }
        private void Registration_Preparing(object sender, PreparingEventArgs args)
        {
            var forType = args.Component.Activator.LimitType;
            var logParameter = new ResolvedParameter(
                (p, c) => p.ParameterType == typeof(ILogger),
                (p, c) => c.Resolve<ILogger>(TypedParameter.From(forType)));
            args.Parameters = args.Parameters.Union(new[] { logParameter });
        }
    }
