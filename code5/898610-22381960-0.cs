    public class DNS_Log 
    {
        public string Destination{ get; set; }
        public int Source_IP { get; set; }
        public string Domain_Controller { get; set; }
        public DateTime DateTime { get; set; }
        public override bool Equals(object obj)
        {
            DNS_Log c2 = obj as DNS_Log;
            if (obj == null) return false;
            return Destination == c2.Destination && Source_IP == c2.Source_IP
                && Domain_Controller == c2.Domain_Controller && DateTime == c2.DateTime;
        }
        public override int GetHashCode()
        {
            unchecked 
            {
                int hash = 17;
                hash = hash * 23 + Destination.GetHashCode();
                hash = hash * 23 + Source_IP;
                hash = hash * 23 + Domain_Controller.GetHashCode();
                hash = hash * 23 + DateTime.GetHashCode();
                return hash;
            }
        }
    }
     
