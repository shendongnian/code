    // something like this
    class Address  : IComparable<Address>
    {
        public int Housenumber { get; set; }
        public string HousenumberExtra { get; set; }
        
        public int CompareTo(Address other)
        {
            var compareResult = Housenumber.CompareTo(other.Housenumber);
            
            if (compareResult == 0)
                return HousenumberExtra.CompareTo(other.HousenumberExtra);
            return compareResult;
        }
    }
