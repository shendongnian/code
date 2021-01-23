    public class Address
    {
        private const string UnknownMessage = "Unknown";
        private const string AddressStringFormat = 
           "Addres Line 1: {0}, Address Line 2: {1}, City: {2}, State: {3}, Zip: {4}";
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public Address(string addressLine1, string addressLine2, string city, string state, string zip)
        {
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
            this.City = city;
            this.State = state;
            this.Zip = zip;
        }
        public string GetStringRepresentation()
        {
            return String.Format(AddressStringFormat, 
                String.IsNullOrWhiteSpace(AddressLine1) ? UnknownMessage : AddressLine1,
                String.IsNullOrWhiteSpace(AddressLine2) ? UnknownMessage : AddressLine2,
                String.IsNullOrWhiteSpace(City) ? UnknownMessage : City,
                String.IsNullOrWhiteSpace(State) ? UnknownMessage : State,
                String.IsNullOrWhiteSpace(Zip) ? UnknownMessage : Zip);
        }
    }
