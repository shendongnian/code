    using FluentValidation;
    using Ninject.Extensions.Conventions;
    using Ninject.Modules;
    public class ValidatorModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(
                x =>
                x.FromAssembliesMatching("YourNameSpace.*")
                 .SelectAllClasses()
                 .InheritedFrom<IValidator>()
                 .BindAllInterfaces());
        }
    }
