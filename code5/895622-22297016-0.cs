    public class AuthorizeDesignatedRoles : AuthorizeAttribute
    {
    	public const string DELETE = "GroupAuthorizedForDeleteAction";
    	
    	public string DesignatedRoles { get; set; }
    	
    	protected override bool IsAuthorized(System.Web.Http.Controllers.HttpActionContext actionContext) {
    	{
    		// ...
    	
    		string[] roles = DesignatedRoles.Split(';')
    										.Select(s => ConfigurationManager.AppSettings[s].ToString());
    		
    		foreach (string role in roles)
    		{
    			// ...
    		}
    	}
    }
