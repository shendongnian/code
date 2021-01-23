	public class MyObject
	{
		public bool result;
		public string reason;
	}
	
	public class TestController : ApiController
	{
		public MyObject GetData()
		{
			MyObject result = new MyObject { result = "true", reason = "Testing POCO return" };
			return result;
		}
	}
