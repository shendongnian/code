    	[ServiceContract]
    	public interface IEvents
    	{
    		[WebInvoke (Method = "GET", UriTemplate = "?venue={venue}")]
    		string GetEvents (string venue);
    	}
    	public class Events : IEvents
    	{
    		public string GetEvents (string venue)
    		{
    			return "This would contain event data.";
    		}
    	}
