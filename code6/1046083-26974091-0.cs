    public interface ISubDomainProvider
    {
    	string SubDomain { get; set; }
    }
    public class SubDomainProvider : ISubDomainProvider
    {
    	public SubDomainProvider()
	    {
	        string host = HttpContext.Current.Request.Url.Host; // not checked (off the top of my head
	    	if (host.Split('.').Length > 1) 
			{
		    	int index = host.IndexOf(".");
		    	string subdomain = host.Substring(0, index);
		    	if (subdomain != "www") 
				{
		    		SubDomain = subdomain;
	    		}
	    	}
	    }
    
    	public string SubDomain { get; set; }
    }
