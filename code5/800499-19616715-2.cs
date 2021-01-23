    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
        if (!controllerContext.HttpContext.Request.ContentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
        {
            return null;
        }
        controllerContext.HttpContext.Request.InputStream.Position = 0;
        using (var reader = new StreamReader(controllerContext.HttpContext.Request.InputStream))
        {
            var json = reader.ReadToEnd();
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }
            dynamic result = new ExpandoObject();
            var deserializedObject = new JavaScriptSerializer().DeserializeObject(json) as IDictionary<string, object>;
            if (deserializedObject != null)
            {
                foreach (var item in deserializedObject)
                {
                    ((IDictionary<string, object>)result).Add(item.Key, item.Value);
                }
            }
            return result;
        }
    }
