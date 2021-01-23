    Hi I also got same error because I made mistake of having unmatched data type between DB and model class.
    
    public string DepartmentID { get; set; } != int DepartmentID of table.
    
    It worked when I fixed it.
    
    Below is my example:
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    
    namespace Part10MVC.Models
    {
        [Table("tblDepartment")]
    
        public class Department
        {
            public int ID { get; set; }
            public string Name { get; set; }
           public List<Employee> Employees { get; set; }
        }
    }
    
    
        using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    
    namespace Part10MVC.Models
    {
        [Table("tblEmployee")]
        public class Employee
        {
            public int employeeID { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public string City { get; set; }
            public int DepartmentID { get; set; }
        }
    }
    
    
    
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    
    namespace Part10MVC.Models
    {
        
        public class EmployeeContext: DbContext
        {
          public  DbSet<Employee> Employees { get; set; }
            public DbSet<Department> Departments { get; set; }
        }
    }
    
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Part10MVC.Models;
    
    namespace Part10MVC.Controllers
    {
        public class DepartmentController : Controller
        {
            //
            // GET: /Department/
    
            public ActionResult showDepartment()
            {
                EmployeeContext ec = new EmployeeContext();
                List<Department> departments =ec.Departments.ToList();
                return View(departments);
            }
    
        }
    }
    
        
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Part10MVC.Models;
    
    namespace Part10MVC.Controllers
    {
        public class EmployeeController : Controller
        {
            //
            // GET: /Employee/
    
            public ActionResult showEmployees(int id)
            {
                EmployeeContext ec = new EmployeeContext();
                List<Employee> liEmp = ec.Employees.Where(x=>x.DepartmentID==id).ToList();
                return View(liEmp);
            }
    
        }
    }
