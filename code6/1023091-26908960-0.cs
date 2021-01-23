    [Table(Name = "Customers")]
    public class Customer
    {
        [PrimaryKey, Identity]
        public int CompanyID { get; set; }
        [Column(Name="CompanyName"), NotNull]
        public string Name { get; set; }
        [Association(OtherKey = "CompanyID", ThisKey = "CompanyID", CanBeNull = true)]
        public Account Accounts { get; set; }
    }
