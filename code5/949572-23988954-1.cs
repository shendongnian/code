	public class HelloController : ApiController
	{
		[AllowReferrer]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}
	}
