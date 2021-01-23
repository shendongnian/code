    public class Customer
    {
        [AutoIncrement]
        [Alias("CustomerId")]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    ...
    }
