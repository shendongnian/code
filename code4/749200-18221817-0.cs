    public class SearchResult
    {
    	public string EventType {get ;set;}
    	public string User {get ; set;}
    	public DateTime Date {get;set;}
    	public int PCBID {get;set;}
    	public string Reason {get;set;}
    	
    	public string UserAndIP
    	{
    		get
    		{
    			return String.Format("{0}:192.168.255.255",User);
    		}
    	}
    	
    	public string ActionId
    	{
    		get
    		{
    			return String.Format("{0:X4}", new Random().Next(0xffff));
    		}
    	}
    }
