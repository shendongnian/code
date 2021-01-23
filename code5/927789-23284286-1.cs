    using System.Net;
    using System.Web;
    using System.Web.Mvc;
        
    public class MyModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var result = base.BindModel(controllerContext, bindingContext);
    
            if (result == null && bindingContext.ModelName.ToLower() == "id")
            {
                throw new HttpException((int)HttpStatusCode.NotFound, null);
            }
    
            return result;
        }
    }
