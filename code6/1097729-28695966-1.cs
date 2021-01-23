    public class DerivedClass : ParentClass
    {
        public string CountryCode
        {
            get; set;
        }
        // we can override phoneNumber
        public override string PhoneNumber
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(base.PhoneNumber)) {
                     return base.PhoneNumber;
                }
                if (!base.PhoneNumber.StartsWith(CountryCode)) {
                    return CountryCode + base.PhoneNumber;
                }
                return base.PhoneNumber;  // you could also return the field phoneNumber instead (as it is protected)
            }
            set
            {
                base.PhoneNumber = CountryCode + value; // you could also set the field phoneNumber ... (we are adding country code here)
            }
        }
        public DerivedClass() : this("0049")
        {
        }
        public DerivedClass(string countryCode) : base() // call the base constructor as well
        {
            // do something more than what the parentclass is doing, eg...
             this.CountryCode = countryCode;
        }
    }
