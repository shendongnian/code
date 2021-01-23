    public class UnityModelValidator : DataAnnotationsModelValidator
    {
        private readonly IUnityContainer unityContainer;
        public UnityModelValidator(ModelMetadata metadata, 
            ControllerContext context, 
            ValidationAttribute attribute)
            : base(metadata, context, attribute)
        {
            this.unityContainer = DependencyResolver.Current.GetService<IUnityContainer>();
        }
        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            try
            {
                unityContainer.BuildUp(Attribute.GetType(), Attribute);
            }
            catch (ResolutionFailedException ex)
            {
                //Don't understand why it sometimes tries to use Unity to create an attribute rather than just build up an existing object. If this happens it can fail but we want to ignore it.
            }
            ValidationContext context = CreateValidationContext(container);
            ValidationResult result = Attribute.GetValidationResult(Metadata.Model, context);
            if (result != ValidationResult.Success)
            {
                yield return new ModelValidationResult
                {
                    Message = result.ErrorMessage
                };
            }
        }
        protected virtual ValidationContext CreateValidationContext(object container)
        {
            var context = new ValidationContext(container ?? Metadata.Model, new UnityServiceLocator(unityContainer), null);
            context.DisplayName = Metadata.GetDisplayName();
            return context;
        }
    }
