    protected void Application_Start()
    {
        /*some code*/
        ModelBinders.Binders.Add(typeof(DateTime), new DateTimeModelBinder());
        ModelBinders.Binders.Add(typeof(DateTime?), new DateTimeModelBinder());
    }
    /// <summary>
    /// Allows to pass date using get using current server's culture instead of invariant culture.
    /// </summary>
    public class DateTimeModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            var date = valueProviderResult.AttemptedValue;
            if (String.IsNullOrEmpty(date))
            {
                return null;
            }
            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);
            
            try
            {
                // Parse DateTimeusing current culture.
                return DateTime.Parse(date);
            }
            catch (Exception)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, String.Format("\"{0}\" is invalid.", bindingContext.ModelName));
                return null;
            }
        }
    }
