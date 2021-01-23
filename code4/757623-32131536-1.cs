    public class MyModelBinder : DefaultModelBinder
    {        
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var actionName = controllerContext.RouteData.Values["Action"];
            if (controllerContext.Controller.GetType() == typeof(MyController) && actionName != null && 
                (string.Compare(actionName.ToString(), "post", StringComparison.OrdinalIgnoreCase) == 0 ||
                string.Compare(actionName.ToString(), "public", StringComparison.OrdinalIgnoreCase) == 0))
            {
                string contentText;
                using (var stream = controllerContext.HttpContext.Request.InputStream)
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    using (var reader = new StreamReader(stream))
                        contentText = reader.ReadToEnd();
                }
                if (string.IsNullOrEmpty(contentText)) return (null);
                return JObject.Parse(contentText);
            }
            return base.BindModel(controllerContext, bindingContext);
        }
    }
