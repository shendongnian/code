    public class Department
    {
        
        public Department()
        {
            List<Employee>  EmployeeList = new List<Employee>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Deptid { get; set; }
        public string Deptname { get; set; }
        
        public virtual ICollection<Employee> Employees { get; set; }
    }
     public class Employee
    {
     
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public int Salary { get; set; }
        public int Deptid  { get; set; }
        [ForeignKey("Deptid ")]
        public virtual Department department { get; set; }
        
    }
