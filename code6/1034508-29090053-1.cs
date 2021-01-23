    public class MemberModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var model = Activator.CreateInstance(bindingContext.ModelType);
            foreach (var prop in bindingContext.PropertyMetadata)
            {
                // Retrieving attribute
                var attr = bindingContext.ModelType.GetProperty(prop.Key)
                                         .GetCustomAttributes(false)
                                         .OfType<DataMemberAttribute>()
                                         .FirstOrDefault();
                // Overwriting name if attribute present
                var qsParam = (attr != null) ? attr.Name : prop.Key;
                // Setting value of model property based on query string value
                var value = bindingContext.ValueProvider.GetValue(qsParam).AttemptedValue;
                var property = bindingContext.ModelType.GetProperty(prop.Key);
                property.SetValue(model, value);
            }
            bindingContext.Model = model;
            return true;
        }
    }
