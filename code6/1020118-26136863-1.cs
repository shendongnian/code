    public class MyModelBinder : IModelBinder
    {
         public object BindModel (ControllerContext controllerContext, ModelBindingContext bindingContext)
         {
              //create your model instance
              //get the values from the bindingContext
              //string myValue = bindingContext.ValueProvider.GetValue(key);
              //return the model
         }
    }
    public class MyModelBinderAttribute : CustomModelBinderAttribute
    {
         public override IModelBinder GetBinder()
         {
              return new MyModelBinder();
         }
    }
