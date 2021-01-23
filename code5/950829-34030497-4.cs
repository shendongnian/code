	internal class JsonNetModelBinder : IModelBinder
	{
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			controllerContext.HttpContext.Request.InputStream.Position = 0;
			var stream = controllerContext.RequestContext.HttpContext.Request.InputStream;
			var readStream = new StreamReader(stream, Encoding.UTF8);
			var json = readStream.ReadToEnd();
			return JsonConvert.DeserializeObject(json, bindingContext.ModelType);
		}
	}
