    using System.ServiceModel;
    
    namespace TestWCFReference
    {
        public class Program
        {
            public void Main(string[] args)
            {
                var endpoint = "http://localhost:5000/MapService.svc";
    			BasicHttpBinding binding = new BasicHttpBinding(); 
    			EndpointAddress endpoint = new EndpointAddress(endpoint);
    			ChannelFactory<IMapService> channelFactory = new ChannelFactory<IMapService>(binding, endpoint);
    			IMapService clientProxy = channelFactory.CreateChannel();
    
    	        var map = clientProxy.GetMap();
                channelFactory.Close();
            }
        }
    }
