    struct DomainName : IEquatable<DomainName>
    {
        public string domainName;
        public ulong domainNameCounter;
        public bool Equals(DomainName other)
        {
            return string.Equals(domainName, other.domainName);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is DomainName && Equals((DomainName) obj);
        }
        public override int GetHashCode()
        {
            return (domainName != null ? domainName.GetHashCode() : 0);
        }
    }
