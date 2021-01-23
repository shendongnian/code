    [ServiceContract]
    	public interface ITestService
    	{
    		[OperationContract]
    		[WebInvoke(Method = "POST", 
    			UriTemplate = TestService.ROUTER_URL, 
    			ResponseFormat = WebMessageFormat.Json
    			BodyStyle = WebMessageBodyStyle.Wrapped)]
    		Message Router(Message message);
    	}
	public class TestClass
	{
		public string test { get; set; }
	}
	public class TestService : ITestService
	{
		public const string ROUTER_URL = "/Router/*";
		public Message Router(Message message)
		{
			
			TestClass testClassInstance;
			using (var reader = new StreamReader(message.GetBody<Stream>()))
			{
				testClassInstance = Newtonsoft.Json.JsonConvert.DeserializeObject<TestClass>(reader.ReadToEnd());
			}
			
			return WebOperationContext.Current.CreateJsonResponse(new { Whatever = "yes"});
		}
	}
