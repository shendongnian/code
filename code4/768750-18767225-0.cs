	public class MongoEntityDataBinder<T> : DefaultModelBinder where T: IDataEntity
	{
		public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			string body;
			using(var stream = controllerContext.HttpContext.Request.InputStream)
			{
				stream.Seek(0, SeekOrigin.Begin);
				using(var reader = new StreamReader(stream))
				{
					body = reader.ReadToEnd();
				}
			}
			if(string.IsNullOrEmpty(body)) return null;
			try
			{
				return JsonConvert.DeserializeObject<T>(body);
			}
			catch(Exception)
			{
				return null;
			}
		}
	}
