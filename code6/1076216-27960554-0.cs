    public class ServiceFacade : IMyWCFService
    {
        private IMyWCFService _clientImplementation;
        public ServiceFacade()
        {
            _clientImplementation = (Settings.Default.UseMockService == true) ? new MockWCFServiceClient() : new MyWcfServiceClient();
            
        }
        #region IMyWCFService implementation
        public int MyServiceCall()
        {
           return _clientImplementation.MyServiceCall();
        }
        #endregion
    }
