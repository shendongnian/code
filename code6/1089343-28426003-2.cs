    public class Address
    {
        //...
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [InverseProperty("Addresses")]
        public virtual Employee Employee { get; set; }
    }
