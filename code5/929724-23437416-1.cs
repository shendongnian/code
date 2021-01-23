    public class DAModelValidatorProvider : DataAnnotationsModelValidatorProvider
    {
        protected override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context, IEnumerable<Attribute> attributes)
        {
            var validators = base.GetValidators(metadata, context, attributes).ToList();
            // get root validators of the collection. this was stored in the editor template - fetching it for use now.
            // fetching the rootvalidators inside this method is a bad idea because we have to call GetValidators method on the 
            // containers ModelMetadata and it will result in a non-terminal recursion
            var rootValidators = context.HttpContext.Items["rootValidators"] as IEnumerable<ModelValidator>;
            if (rootValidators != null)
            {
                foreach (var rootValidator in rootValidators)
                {
                    validators.Add(rootValidator);
                }
            }
            return validators;
        }
    }
