Install-Package Microsoft.AspNet.WebApi.OwinSelfHost
Program.cs
    internal class Program
    {
    	private static IDisposable _server;
    
    	private static void Main(string[] args)
    	{
    		_server = WebApp.Start<Startup>("http://localhost:12345");
    		Console.ReadLine();
    		_server.Dispose();
    	}
    }
Startup.cs
    public class Startup
    {
    	public void Configuration(IAppBuilder app)
    	{
    		var config = new HttpConfiguration();
    		WebApiConfig.Register(config);
    		app.UseWebApi(config);
    	} 
    }
WebApiConfig.cs
    public static class WebApiConfig
    {
    	public static void Register(HttpConfiguration config)
    	{
    		var userTokenInspector = new UserTokenInspector {InnerHandler = new HttpControllerDispatcher(config)};
    		config.Routes.MapHttpRoute(
    			"UserAuthenticationApi",
    			"api/{controller}/Authenticate",
    			new {controller = "User", action = "Authenticate"},
    			null
    			);
    
    		config.Routes.MapHttpRoute(
    			"DefaultApi",
    			"api/{controller}/{id}",
    			new {id = RouteParameter.Optional},
    			null,
    			userTokenInspector
    			);
    	}
    }
UserTokenInspector.cs
    public class UserTokenInspector : DelegatingHandler {
    	protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
    	CancellationToken cancellationToken) {
    		const string TOKEN_NAME = "X-Token";
    
    		if (!request.Headers.Contains(TOKEN_NAME)) {
    			return Task.FromResult(request.CreateErrorResponse(HttpStatusCode.Unauthorized,
    			"Request is missing authorization token."));
    		}
    
    		try {
    			//var token = UserToken.Decrypt(request.Headers.GetValues(TOKEN_NAME).First());
    
    			// validate token
    			// ...
    			// ...
    
    			Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("alex"), new string[] { });
    		}
    		catch {
    			return Task.FromResult(request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid token."));
    		}
    
    		return base.SendAsync(request, cancellationToken);
    	}
    }
UserController.cs
    public class UserController : ApiController
    {
    	public long Post(UserDTO userDTO)
    	{
    		// create user and return custom result
    		// code (e.g. success, duplicate email, etc...)
    		return 1;
    	}
    }
UserDto.cs
    public class UserDTO
    {
    	public string Username { get; set; }
    }
ValuesController.cs
    public class ValuesController : ApiController
    {
    	public HttpResponseMessage Get()
    	{
    		return Request.CreateResponse(HttpStatusCode.OK, "yay");
    	}
    }
