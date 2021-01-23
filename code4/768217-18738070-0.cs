    public class ServiceToBeTested : ServiceBase
    {
        private IAppJobManagement _appJobManagment;
        public ServiceToBeTested()
        {
            _appJobManagment = new AppJobManagement();
        }
        internal ServiceToBeTested(IAppJobManagement appJobManagment)
        {
            _appJobManagment = appJobManagment;
        }
    }
