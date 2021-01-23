    public class DNS_Log : IEquatable<DNS_Log>
    {
        public bool Equals(DNS_Log other)
        {
            if (other == null)
                return false;
            return (other.Destination == Destination
                    && other.Source_IP == Source_IP
                    && other.Domain_Controller == Domain_Controller
                    && other.DateTime == DateTime);
        }
        public override int GetHashCode()
        {
            int hash = 23;
            hash = hash * 59 + (Destination == null ? 0 : Destination.GetHashCode());
            hash = hash * 59 + (Source_IP == null ? 0 : Source_IP.GetHashCode());
            hash = hash * 59 + (Domain_Controller == null ? 0 : Domain_Controller.GetHashCode());
            hash = hash * 59 + DateTime.GetHashCode();
            return hash;
        }
    }
