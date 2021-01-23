    public class CustomBinder : IModelBinder
    {
    public object BindModel(ControllerContext controllerContext, 
                            ModelBindingContext bindingContext)
    {
        HttpRequestBase request = controllerContext.HttpContext.Request;
        string idViewModel= request.Form.Get("idViewModel");
        string description= request.Form.Get("description");
        var list = new List<anotherViewModel>(); //create list from form data
        
        return new ViewModel
                   {
                       idViewModel= idViewModel,
                       description= description,
                       aViewModel = list
                   };
    }
