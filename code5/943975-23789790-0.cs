    internal DataClass : IDataClass
    {
        private readonly ISessionWithServerUri _session;
    
        public DataClass(ISessionWithServerUri session)
        {
            _session = session; // Look, no cast!
        }
    
        // some more methods that access the internal property _session.ServerUri
        // and call methods on the session object
        // ...
    }
