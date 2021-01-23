    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		
    		var employees = new List<Employee> { new Employee {Name = "MY_NAME1", CorrelationID = "CID1"}, new Employee {Name = "MY_NAME2", CorrelationID = "CID2"}, new Employee {Name = "MY_NAME3", CorrelationID = "CID3"}};
    		var depts = new List<Department> { new Department {Name = "DEPT_NAME1", CorrelationID = "CID2"}, new Department {Name = "DEPT_NAME2", CorrelationID = "CID1"}};
    		
    		var joined = employees.Join(depts, x => x.CorrelationID, x => x.CorrelationID, (employee, dept) => new {EmployeeName = employee.Name, DepartmentName = dept.Name});
    		
    		foreach(var pair in joined){
    			Console.WriteLine("EmployeeName: {0}, DepartmentName: {1}", pair.EmployeeName, pair.DepartmentName);
    		}
    	}
    	
    	public class Employee
    	{
    		public string Name {get;set;}
    		public string CorrelationID {get;set;}
    	}
    	
    	public class Department
    	{
    		public string Name {get;set;}
    		public string CorrelationID {get;set;}
    	}
    	
    	public class SqlBuilder{
    		
    		private static string _baseSql = "select * from customers";
    		
    		public static string GetSql(string customerId){
    			var final = _baseSql;
    			if(customerId != null)
    				final += " WHERE custId=@custId";
    			return final;
    		}
    	}
    }
