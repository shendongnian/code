    public class User
    {
        [Key, Column("USER_ID")]
        public decimal ID { get; set; }
        
        ...
        
        [Column("EMPLOYEE_ID")]
        public string EmployeeID { get; set; }
        
        public Employee Employee { get; set; } // You need this property
    }
