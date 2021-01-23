    public class Customer
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
