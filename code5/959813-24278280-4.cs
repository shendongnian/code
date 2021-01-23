    public class FileHandler : IHttpHandler
    {
    	public void ProcessRequest(HttpContext context)
    	{
            var path = GetPath(context.Request.Params["Id"]);
    	    context.Response.ContentType = "image/jpeg";
    	    context.Response.WriteFile(path);
    	}
    }
