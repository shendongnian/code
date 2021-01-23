    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
    	public override bool AuthorizeHubConnection(HubDescriptor hubDescriptor, IRequest request)
    	{
    		//put our custom user-principal into a magic "server.User" Owin variable
    		request.Environment["server.User"] = new MyCustomPrincipal(); //<!-THIS!
    
    		return base.AuthorizeHubConnection(hubDescriptor, request);
    	}
    }
