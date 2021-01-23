    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    
    namespace TestConsole
    {
        public class Employee
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public virtual Employment EmploymentDetails { get; set; }
    }
    public class Employment
    {
        [Key, ForeignKey("Employee")]
        public int ID { get; set; }
        public string Department { get; set; }
        public int OfficePhone { get; set; }
        public virtual Employee Employee { get; set; }
        }
    
    
        internal class Program
        {
            public TestConsoleDbContext MyDbContext { get; set; }
    
            public Program()
            {
                MyDbContext = new TestConsoleDbContext();
            }
    
            private static void Main(string[] args)
            {
    
                var program = new Program();
    
                var records = from p in program.MyDbContext.Employees
                              select new { p.EmploymentId, p.LastName, p.Employment.Department };
    
                foreach (var r in records)
                {
                    Console.WriteLine("EmploymentID: {0} {1} Department: {2}", r.EmploymentId, r.Department);
                }
    
                Console.ReadLine();
    
    
            }
        }
    }
    using System.Data.Entity;
    
    namespace TestConsole
    {
        internal class TestDbContext : DbContext
        {
            public IDbSet<Employee> Employees { get; set; }
            public IDbSet<Employment> Employments { get; set; }
        }
    }
