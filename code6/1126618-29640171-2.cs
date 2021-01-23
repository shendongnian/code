    namespace Call_WCF_WebService_REST_With_jQuery.service
    {
    	[ServiceContract(Namespace = "")]
    	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    	public class AjaxService
    	{
    		// To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
    		// To create an operation that returns XML,
    		//     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
    		//     and include the following line in the operation body:
    		//         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
    		[OperationContract]
    		public Person DoWork()
    		{
    			// Add your operation implementation here
    			return new Person() { Age = 12, Name = "Jo" };
    		}
    
    		// Add more operations here and mark them with [OperationContract]
    	}
    }
