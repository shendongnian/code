    public class UnityModelValidator : DataAnnotationsModelValidator
    {
        private readonly IUnityContainer unityContainer;
        public UnityModelValidator(ModelMetadata metadata, 
            ControllerContext context, 
            ValidationAttribute attribute,
            IUnityContainer unityContainer)
            : base(metadata, context, attribute)
        {
            this.unityContainer = unityContainer;
        }
        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            unityContainer.BuildUp(Attribute.GetType(), Attribute);
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
