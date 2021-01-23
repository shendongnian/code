    public class User
    {
        #region private
        [JsonProperty("key")]
        private string _Key { set { Key = value; } }
    
        [JsonProperty("field1")]
        private string _FirstName { set { FirstName = value; } }
    
        [JsonProperty("field2")]
        private string _LastName { set { LastName = value; } }
    
        [JsonProperty("address")]
        private Address _Address { set { Address = value; } }
        #endregion
        #region public
        [JsonProperty("Key")]
        public string Key { get; private set; }
    
        [JsonProperty("FirstName")]
        public string FirstName { get; private set; }
    
        [JsonProperty("LastName")]
        public string LastName { get; private set; }
    
        [JsonProperty("Address")]
        public Address Address { get; private set; }
        #endregion
    }
    
    public class Address
    {
        #region private
        
        [JsonProperty("field3")]
        private string _Street { set { Key = value; } }
    
        [JsonProperty("field4")]
        private string _City { set { FirstName = value; } }
        
        #endregion
        #region public
        [JsonProperty("Street")]
        public string Street { get; private set; }
    
        [JsonProperty("City")]
        public string City { get; private set; }
        #endregion
    }
