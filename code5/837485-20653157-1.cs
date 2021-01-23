    public class YourViewModel
    {
        public List<Customer> Customers { get; set; }
        public Customer SelectedCustomer { get; set; }
    }
    
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
    }
    
    public class Gender
    {
        public int GenderID { get; set; }
        public string Value { get; set; }
    }
