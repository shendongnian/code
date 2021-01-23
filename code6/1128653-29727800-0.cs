    public class MyBinder : DefaultModelBinder {
    
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
    
            if (bindingContext.ModelType.Equals(typeof(CustomType))) {
                // get an instance of the model using the model prefix
                string parameter = controllerContext.HttpContext.Request.Form[bindingContext.ModelName];
                object model = controllerContext.HttpContext.Cache[parameter];
    
                // populate the remaining model properties using reflection (yuck)
                MethodInfo bindComplexElementalModel =
                    base.GetType().GetMethod("BindComplexElementalModel", BindingFlags.NonPublic | BindingFlags.Instance);
                bindComplexElementalModel.Invoke(this, new object[] { controllerContext, bindingContext, model });
                return model;
            }
    
            return base.BindModel(controllerContext, bindingContext);
        }
    }
