    using Ninject.Extensions.Conventions;
    // Bind all the non-composite IValidationRules for injection into ValidationRuleComposite
    kernel.Bind(x => x.FromAssemblyContaining(typeof(ValidationRuleComposite))
        .SelectAllClasses()
        .InheritedFrom<IValidationRule>()
        .Excluding<ValidationRuleComposite>()
        .BindAllInterfaces()
        .Configure(c => c.WhenInjectedInto<ValidationRuleComposite>()));
