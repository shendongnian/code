        var ninjectValidatorFactory = new NinjectValidatorFactory(kernel);
        FluentValidationModelValidatorProvider
          .Configure(x => x.ValidatorFactory = ninjectValidatorFactory);
        // Bind all Fluent validators to their implementation.
        AssemblyScanner.FindValidatorsInAssembly(Assembly.GetExecutingAssembly())
            .ForEach(match => kernel.Bind(match.InterfaceType).To(match.ValidatorType));
