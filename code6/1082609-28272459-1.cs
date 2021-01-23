    public class User
    {
        #region private
        // Other fields, see above. \\
    
        [JsonProperty("address")]
        private Address _Address 
        { 
            set 
            { 
                City = value.City;
                Street = value.Street;
            } 
        }
        #endregion
        #region public
        // Other fields, see above. \\
    
        [JsonProperty("City")]
        public string City { get; private set; }
        [JsonProperty("Street")]
        public string Street { get; private set; }
        #endregion
    }
    
    public class Address
    {
        // Address fields. See above.
    }
