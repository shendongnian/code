    using System.Web.Mvc;
    using Newtonsoft.Json;
    namespace Namespace.Web.Core.Binders
    {
        public class JsonBinder<T> : IModelBinder
        {
           public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                var jsonString = controllerContext.RequestContext.HttpContext.Request.Params[0];
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
        }
    }
