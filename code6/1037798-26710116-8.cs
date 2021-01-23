    public class JsonModelBinder : DefaultModelBinder
    {
        public static JsonSerializerSettings GlobalSerializerSettings
        {
            get
            {
                return new JsonSerializerSettings()
                {                    
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),                    
                    Converters = { new IsoDateTimeConverter() }
                };
            }
        }
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (!IsJSONRequest(controllerContext))
            {
                return base.BindModel(controllerContext, bindingContext);
            }
            // Get the JSON data that's been posted
            var request = controllerContext.HttpContext.Request;
            request.InputStream.Seek(0, SeekOrigin.Begin);
            var streamReader = new StreamReader(request.InputStream);
            var jsonStringData = streamReader.ReadToEnd();
            if (string.IsNullOrEmpty(jsonStringData))
                return null;
            return JsonConvert.DeserializeObject(jsonStringData, bindingContext.ModelMetadata.ModelType, GlobalSerializerSettings);
        }
        protected static bool IsJSONRequest(ControllerContext controllerContext)
        {
            var contentType = controllerContext.HttpContext.Request.ContentType;
            return contentType.Contains("application/json");
        }
    }
