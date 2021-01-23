    public class Handler : IHttpHandler 
    {
        public void ProcessRequest (HttpContext context) 
    	{
    		// relevant context.Response lines
    	}
    
        public bool IsReusable 
        {
    		get { return false; }
    	}
    }
