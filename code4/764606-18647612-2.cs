    public class CustomModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            IValueProvider provider = bindingContext.ValueProvider;
            // Check whether we have a list or a single object.  If we have a list
            // then all the properties will be prefixed with an index in square brackets.
            if (provider.ContainsPrefix("[0]"))
            {
                // We have a list.  Since that is what the controller method is 
                // expecting, just use the default model binder to do the work for us.
                return ModelBinders.Binders.DefaultBinder.BindModel(controllerContext, bindingContext);
            }
            else
            {
                // We have a single object.
                // Bind it manually and return it in a list.
                ClassA a = new ClassA();
                a.ID = GetValue<int>(provider, "ID");
                a.FirstName = GetValue<string>(provider, "FirstName");
                a.LastName = GetValue<string>(provider, "LastName");
                return new List<ClassA> { a };
            }
        }
        private T GetValue<T>(IValueProvider provider, string key)
        {
            ValueProviderResult result = provider.GetValue(key);
            return (result != null ? (T)result.ConvertTo(typeof(T)) : default(T));
        }
    }
