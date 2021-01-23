    public class Employees
    {
        //...
        [InverseProperty("Employee")]
        public virtual ICollection<Address> Addresses { get; set; }
    }
    public class Address
    {
        //...
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId"), InverseProperty("Addresses")]
        public virtual Employees Employee { get; set; }
    }
