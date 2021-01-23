        /// <summary>
        /// In case a backplane  is used (in case of load balancer) , the instance should always be taken fresh
        /// if no backplane is used no need to refresh the instance on each invocation
        public class HubContextService 
        {
            bool BackplaneUsed { get; set; }
            IHubContext _context = null;
    
            public  HubContextService(bool isBackPlaneUsed = true)
            {
                BackplaneUsed = isBackPlaneUsed;
            }
    
            public IHubContext HubContext
            { 
                get
                {
                    if (BackplaneUsed)
                    {
                        return GlobalHost.ConnectionManager.GetHubContext<HubManager>();
                    }
                    else
                    {
                        if (_context == null)
                        {
                            _context = GlobalHost.ConnectionManager.GetHubContext<HubManager>(); 
                        }
                        return _context;
                    }
                }
                set 
                {
                    _context = value;
                }
            }
        }
