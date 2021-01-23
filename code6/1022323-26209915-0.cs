    public class Employee
    {
       public int id { get; set; }
       public string Name { get; set; }
       public int Salary { get; set; }
       public int Deptid { get; set; }
  
       [ForeignKey("Deptid")]
       public virtual Department Department { get; set; }
    }
    public class Department
    {
       [Key]
       public int Deptid { get; set; }
       public string Deptname { get; set; }
    }
