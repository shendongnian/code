    public sealed class ActorDtoModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var actor = new Actor();
            var firstNameValueResult = bindingContext.ValueProvider.GetValue(CreateFullPropertyName(bindingContext, "First_Name"));
            if(firstNameValueResult != null) {
                actor.FirstName = firstNameValueResult.AttemptedValue;
            }
            var lastNameValueResult = bindingContext.ValueProvider.GetValue(CreateFullPropertyName(bindingContext, "Last_Name"));
            if(lastNameValueResult != null) {
                actor.LastName = lastNameValueResult.AttemptedValue;
            }
            bindingContext.Model = actor;
            bindingContext.ValidationNode.ValidateAllProperties = true;
            return true;
        }
        private string CreateFullPropertyName(ModelBindingContext bindingContext, string propertyName)
        {
            if(string.IsNullOrEmpty(bindingContext.ModelName))
            {
                return propertyName;
            }
            return bindingContext.ModelName + "." + propertyName;
        }
    }
