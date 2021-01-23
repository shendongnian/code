    public class PortNumberAttribute : Attribute
    {
    	public int PortNumber { get; set; }
    	public PortNumberAttribute(int port)
    	{
    		PortNumber = port;
    	}
    }
    
    [PortNumber(8085)]
    public interface IEventsService
    {
    	//service methods etc
    }
    
    
    string baseUri = "http://foo.com:{0}";
    Type iface = typeof(IEventsService);
    PortNumberAttribute pNumber = (PortNumberAttribute)iface.GetCustomAttribute(typeof(PortNumberAttribute));
    Uri newUri = new Uri(string.Format(baseUri, pNumber.PortNumber));
    
    //create host and all that
