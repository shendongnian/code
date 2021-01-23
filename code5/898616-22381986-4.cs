    dnsLogs = dnsLogs.Distinct(new DNS_LogEqualityComparer()).ToList();
    public class DNS_LogEqualityComparer : IEqualityComparer<DNS_Log>
    {
        public int GetHashCode(DNS_Log obj)
        {
            int hash = 23;
            hash = hash * 59 + (obj.Destination == null ? 0 : obj.Destination.GetHashCode());
            hash = hash * 59 + (obj.Source_IP == null ? 0 : obj.Source_IP.GetHashCode());
            hash = hash * 59 + (obj.Domain_Controller == null ? 0 : obj.Domain_Controller.GetHashCode());
            hash = hash * 59 + obj.DateTime.GetHashCode();
            return hash;
        }
        public bool Equals(DNS_Log x, DNS_Log y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x == null) return false;
            return (x.Destination == y.Destination
                && x.Source_IP == y.Source_IP
                && .Domain_Controller == y.Domain_Controller
                && x.DateTime == y.DateTime);
        }
    }
