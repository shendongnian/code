    public class FileHandler : IHttpHandler
    {
    	public void ProcessRequest(HttpContext context)
    	{
    		context.Response.ContentType = "image/jpeg";
    		context.Response.WriteFile(path);
    	}
    }
