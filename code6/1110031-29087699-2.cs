    public class CallbackModule : Module
    {
        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            if (registration.Services.OfType<TypedService>()
                                     .Any(s => s.ServiceType == typeof(IJob)))
            {
                registration.Preparing += (sender, e) =>
                {
                    // bind ICallback and IJob here
                    if (registration.Activator.LimitType == typeof(Job1))
                    {
                        e.Parameters = e.Parameters
                                        .Concat(new TypedParameter[] { TypedParameter.From<ICallback>(e.Context.Resolve<Worker1>()) });
                    }
                };
            }
        }
    }
