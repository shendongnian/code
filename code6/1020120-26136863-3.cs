    public class MyModelBinder : IModelBinder
    {
         public object BindModel (ControllerContext controllerContext, ModelBindingContext bindingContext)
         {
             MyModel model = new MyModel();
             //model.MyProp1 = controllerContext.HttpContext.Request.Form["MyProp1"];
             //model.MyProp2 = controllerContext.HttpContext.Request.Form["MyProp2"];
             //or
             model.MyProp1 = controllerContext.HttpContext.Request.QueryString["MyProp1"];
             model.MyProp2 = controllerContext.HttpContext.Request.QueryString["MyProp2"];
             return model;
         }
    }
