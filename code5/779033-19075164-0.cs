    /// <summary>
    /// The fluent validation model validator provider ex.
    /// </summary>
    internal class FluentValidationModelValidatorProviderEx : FluentValidationModelValidatorProvider
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="FluentValidationModelValidatorProviderEx"/> class.
        /// </summary>
        /// <param name="validatorFactory">
        /// The validator factory.
        /// </param>
        public FluentValidationModelValidatorProviderEx(IValidatorFactory validatorFactory) : base(validatorFactory)
        {
        }
        /// <summary>
        /// get the fluent validators.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <param name="context">The context.</param>
        /// <returns>the set of validators, if any validators are resolved.</returns>
        /// <remarks>If the fluent validator(s) are supplied, then clear the current set of model errors.</remarks>
        public override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context)
        {
            var validators = base.GetValidators(metadata, context);
            var modelValidators = validators as ModelValidator[] ?? validators.ToArray();
            if (modelValidators.Any())
                context.Controller.ViewData.ModelState.Clear();
            return modelValidators;
        }
        /// <summary>
        /// configure fluent validation.
        /// </summary>
        /// <param name="configurationExpression">The configuration expression.</param>
        internal static void ConfigureFluentValidation(Action<FluentValidationModelValidatorProvider> configurationExpression = null)
        {
            configurationExpression = configurationExpression ?? (Action<FluentValidationModelValidatorProvider>)(param0 => { });
            FluentValidationModelValidatorProvider validatorProvider = new FluentValidationModelValidatorProviderEx((IValidatorFactory)null);
            configurationExpression(validatorProvider);
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            ModelValidatorProviders.Providers.Add((ModelValidatorProvider)validatorProvider);
        }
    }
