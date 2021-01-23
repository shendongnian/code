    using System;
    using System.Globalization;
    using System.Web.Mvc;
    
    public class IntModelBinder : IModelBinder
    {
        #region Implementation of IModelBinder
    
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) 
    	{
            ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            ModelState modelState = new ModelState { Value = valueResult };
    		bindingContext.ModelState[bindingContext.ModelName] = modelState;
    		
            object actualValue = null;
            try 
    		{
                actualValue = Int32.Parse(valueResult.AttemptedValue, NumberStyles.Number, CultureInfo.InvariantCulture);
            }
            catch (FormatException e) 
    		{
                modelState.Errors.Add(e);
            }
    
            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
            return actualValue;
        }
    
        #endregion
    }
    //In Application_Start()
    //ModelBinders.Binders.Add(typeof(int), new IntModelBinder());
