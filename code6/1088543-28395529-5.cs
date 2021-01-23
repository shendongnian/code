    public class FluentValidationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // registers type validators
            builder.RegisterGenerics(typeof(IValidator<>));
            // registers the Object Validator and configures the Ambient Singleton container
            builder
                .Register(context =>
                        SystemValidator.SetFactory(() => new FluentValidationObjectValidator(context.Resolve<IDependencyResolver>())))
                .As<IObjectValidator>()
                .InstancePerLifetimeScope()
                .AutoActivate();
        }
    }
