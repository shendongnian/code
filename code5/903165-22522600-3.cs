    public class MyCustomBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.RequestContext.HttpContext.Request;
            var dictionary = new Dictionary<string, string>();
            foreach(var item in request.QueryString.Keys.Cast<string>())
            {
                dictionary.Add(item, request.QueryString[item]);
            }
            return dictionary;
        }
    }
    // On your controller:
    public ActionResult Index([ModelBinder(typeof(MyCustomBinder))] Dictionary<string, string> model)
