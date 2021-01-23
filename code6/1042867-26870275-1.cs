    public class CustomBinder : IModelBinder
    {
      public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
      {
        HttpRequestBase request = controllerContext.HttpContext.Request;
        string name = request.Form.Get("Name");    
        return name
      }
    } 
