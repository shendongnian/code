    public class User // Principal
    {
        public int UserID { get; set; } // PK
        public virtual Employee Employee { get; set; }
    }
    public class Employee // Dependent
    {
        public int EmployeeID { get; set; } // PK
        // public int UserID {get; set; } // remove to create independent association
        public virtual User User { get; set; }
    }
