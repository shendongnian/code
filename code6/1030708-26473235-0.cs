    struct DomainName
    {
        public string domainName;
        public ulong domainNameCounter;
        public override bool Equals(object obj)
        {
            if (obj is DomainName)
            {
                return ((DomainName) obj).domainName == domainName;
            }
            return false;
        }
    }
