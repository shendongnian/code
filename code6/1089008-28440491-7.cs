    using System.ServiceModel;
    
    namespace TestWCFReference
    {
        public class Program
        {
            public void Main(string[] args)
            {
                var endpointUrl = "http://localhost:5000/MapService.svc";
    			BasicHttpBinding binding = new BasicHttpBinding(); 
    			EndpointAddress endpoint = new EndpointAddress(endpointUrl);
    			ChannelFactory<IMapService> channelFactory = new ChannelFactory<IMapService>(binding, endpoint);
    			IMapService clientProxy = channelFactory.CreateChannel();
    
    	        var map = clientProxy.GetMap();
                channelFactory.Close();
            }
        }
    }
