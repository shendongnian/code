    public class Program
    {
    	static void Main (string[] args)
    	{
    		var venueHost = new WebServiceHost (typeof (Venues));
    		venueHost.AddServiceEndpoint (typeof (IVenues), new WebHttpBinding (), "http://localhost:12345/venues");
    		venueHost.Open ();
    		var eventHost = new WebServiceHost (typeof (Events));
    		eventHost.AddServiceEndpoint (typeof (IEvents), new WebHttpBinding (), "http://localhost:12345/events");
    		eventHost.Open ();
    		while (true)
    		{
    			var k = Console.ReadKey ();
    			if (k.KeyChar == 'q' || k.KeyChar == 'Q')
    				break;
    		}
    	}
    }
