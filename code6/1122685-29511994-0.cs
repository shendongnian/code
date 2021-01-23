    [Alias("Customers")]
    public class Customer : IHasId<string>
    {
        [Alias("AccountCode")]
        public string Id { get; set; }
        public string CustomerName { get; set; }
        // ... a load of other fields
    }
