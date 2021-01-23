    	[ServiceContract]
    	public interface IVenues
    	{
    		[WebInvoke (Method = "GET", UriTemplate = "?id={id}")]
    		string GetVenues (string id);
    	}
    	public class Venues : IVenues
    	{
    		public string GetVenues (string id)
    		{
    			return "This would contain venue data.";
    		}
    	}
