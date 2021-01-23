    internal class TaxGroupObject
    {
        public long? EnvelopeID { get; set; }
        public string PolicyNumber { get; set; }
        public string TZ { get; set; }
        
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + EnvelopeID.GetHashCode();
                hash = hash * 23 + (PolicyNumber != null ? PolicyNumber.GetHashCode() : -2);
                hash = hash * 23 + (TZ != null ? TZ.GetHashCode() : -1);
                return hash;
            }
        }
        
        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(TaxGroupObject))
                return false;
            var other = (TaxGroupObject)obj;
            return this.EnvelopeID == other.EnvelopeID &&
                    this.PolicyNumber == other.PolicyNumber &&
                    this.TZ == other.TZ;
        }
    }
