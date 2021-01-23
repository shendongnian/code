    public class MyCustomBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.RequestContext.HttpContext.Request;
            var dictionary = new Dictionary<string, object>();
            foreach(var item in request.QueryString.Keys.Cast<string>())
            {
                // You might want to cast your data into appropriate types...
                dictionary.Add(item, request.QueryString[item]);
            }
            return dictionary;
        }
    }
