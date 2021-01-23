    public class Customer
    {
        public Customer(int customerID, string firstName, string lastName, string address,
                        string zipCode, string city, string email, string phone)
        {
            CustomerID = customerID;
            FirstName = firstName;
            // ...
            Phone = phone;
        }
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
