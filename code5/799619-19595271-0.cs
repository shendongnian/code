    public class DictionaryStringModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Dictionary<string, string> model = new Dictionary<string, string>();
            string contentType = controllerContext.RequestContext.HttpContext.Request.ContentType;
            if (contentType != null && contentType.Contains("application/json"))
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                controllerContext.RequestContext.HttpContext.Request.InputStream.Position = 0;
                string content = new StreamReader(controllerContext.RequestContext.HttpContext.Request.InputStream).ReadToEnd();
                var dynamicContent = Json.Decode(content);
                foreach (string property in dynamicContent.GetDynamicMemberNames())
                {
                    if (property == bindingContext.ModelName)
                    {
                        foreach (string dictionaryProperty in dynamicContent[property].GetDynamicMemberNames())
                        {
                            model.Add(dictionaryProperty, dynamicContent[property][dictionaryProperty]);
                        }
                        break;
                    }
                }
            }
            else
            {
                model = (Dictionary<string, string>)ModelBinders.Binders.DefaultBinder.BindModel(controllerContext, bindingContext);
            }
            return model;
        }
    }
