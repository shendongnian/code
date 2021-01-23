    [DataContract(Name="root", Namespace = "")]
    public class ReturnItem1
    {
        [DataMember(Name = "x_val", Order = 0)]
        public string FirstValue { get; set; }
        [DataMember(Name = "x_val2", Order = 1)]
        public string SecondValue { get; set; }
        [DataMember(Name = "x_addr1", Order = 2)]
        private string _address;
        [DataMember(Name = "x_addr2", Order = 3)]
        private string _address2;
        [DataMember(Name = "x_city", Order = 4)]
        private string _city;
        [DataMember(Name = "x_state", Order = 5)]
        private string _state;
        [DataMember(Name = "x_country", Order = 6)]
        private string _country;
        [DataMember(Name = "x_zip", Order = 7)]
        private string _postalCode;
        public Address AddressInfo { get; set; }
        [OnDeserialized()]
        void OnDeserialized(StreamingContext context)
        {
            AddressInfo = new Address
            {
                Address1 = _address,
                Address2 = _address2,
                PostalCode = _postalCode,
                City = _city,
                Country = _country,
                State = _state
            };
        }
    }
