    internal class CustomModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // use Json.NET to deserialize the incoming Position
            controllerContext.HttpContext.Request.InputStream.Position = 0; // see: http://stackoverflow.com/a/3468653/331281
            Stream stream = controllerContext.RequestContext.HttpContext.Request.InputStream;
            var readStream = new StreamReader(stream, Encoding.UTF8);
            string json = readStream.ReadToEnd();
            return JsonConvert.DeserializeObject<MyClass>(json, ...);
        }
    }
