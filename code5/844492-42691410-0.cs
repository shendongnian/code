    public class LoggingModule : Module
    {
     protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry,
            IComponentRegistration registration)
        {
            registration.Preparing += Registration_Preparing;
        }
    private static void Registration_Preparing(object sender, PreparingEventArgs e)
        {
            var t = e.Component.Activator.LimitType;
            e.Parameters = e.Parameters.Union(
                new[]
                {
                    new ResolvedParameter(
                        (p, i) => p.ParameterType == typeof (ILog),
                        (p, i) => LogFactory.CreateWithType(t))
                });
        }
    }
