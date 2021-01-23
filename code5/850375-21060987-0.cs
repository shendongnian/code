    public sealed class ActorDtoModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var actor = new Actor();
    
            var firstNameValueResult = bindingContext.ValueProvider.GetValue("first_name");
            if(firstNameValueResult != null) {
                actor.FirstName = firstNameValueResult.AttemptedValue;
            }
    
            var lastNameValueResult = bindingContext.ValueProvider.GetValue("last_name");
            if(lastNameValueResult != null) {
                actor.LastName = lastNameValueResult.AttemptedValue;
            }
    
            bindingContext.Model = actor;
    
            bindingContext.ValidationNode.ValidateAllProperties = true;
    
            return true;
        }
    }
