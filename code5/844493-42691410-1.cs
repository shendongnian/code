    public class LoggingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            const string propertyNameKey = "Autofac.AutowiringPropertyInjector.InstanceType";
            builder.RegisterType<NLogLogger>()
                .As<ILog>()
                .OnPreparing(x =>
                {
                    var firstParam = x.Parameters?
                        .OfType<NamedParameter>()
                        .FirstOrDefault(p => p.Name == propertyNameKey);
                    if (null == firstParam)
                    {
                        return;
                    }
                    var valueType = firstParam.Value;
                    x.Parameters = x.Parameters.Union(
                        new[]
                        {
                            new ResolvedParameter(
                                (p, i) => p.Name == "type",
                                (p, i) => valueType)
                        });
                })
                .InstancePerDependency();
