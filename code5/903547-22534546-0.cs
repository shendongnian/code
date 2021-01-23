    class CallClass : IEqualityComparer<CallClass>
    {
        public int ApplicationId { get; set; }
        
        //other propertiec etc.
        public bool Equals(CallClass x, CallClass y)
        {
            return x.ApplicationId == y.ApplicationId;
        }
        public int GetHashCode(CallClass obj)
        {
            return obj.GetHashCode();
        }
    }
