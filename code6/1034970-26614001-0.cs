	public class StringBaseApiController: BaseApiController
	{
			[HttpGet]
			[Route("{controller}/{id:string}")]
			public HttpResponseMessage GetEntity(string id)
			{
				int a;
				if(int.TryParse(id, out a))
				{
					return GetByInt(a);
				}
				return GetByString(id);
			}
			
	}
