    public class TimeSAL : IDisposable
    {
        private ChannelFactory<ITimeService> timeServiceProxyFactory;
        private ITimeService timeServiceProxy;
        private ITimeService TimeService
        {
            get
            {
                //create channel factory if not there
                if (timeServiceProxyFactory == null)
                    timeServiceProxyFactory = new ChannelFactory<ITimeService>(new BasicHttpBinding(), new EndpointAddress("http://url_to_my_timeservice_endpoint"));  //
                if (timeServiceProxy == null)
                    timeServiceProxy = amlProxyFactory.CreateChannel();
                return timeServiceProxy;
            }
        }
        
        public string GetTime()
        {
            return TimeService.GetTime();
        }
       
        public void Dispose()
        {
            //dispose of ChannelFactory and proxy.
            //ensure you check for comm faults to abort before closing
        }
 
    }
