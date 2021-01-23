    public class LoggingDataBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
             var request = context.HttpContext.Request;
             //if you only want to deal with json requests
             if (request.ContentType == "application/json")
             {
                  //can now access QueryString, URL, or InputStream
                  using (var sr = new StreamReader(request.InputStream))
                  {
                     var jsonData = sr.ReadToEnd();
                     LogMethod(jsonData);
                  }    
             }
             return base.BindModel(controllerContext, bindingContext);
        }
    } 
