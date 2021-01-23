    [DataContract(Name="Customer")]
    public class Customer
    {
        [DataMember(Name="CustomerId")]
        public int ID { get; set; }
        // DataMember omitted
        public DateTime? Date { get; set; }
    }
