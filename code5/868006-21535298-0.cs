    using System;
    using System.Collections.Generic;
    using ServiceStack;
    
    
    public class Employee
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    public class EmployeeModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    public class Program
    {
        public static void Main()
        {
            var results = new List<Employee> {
    			new Employee { Id = "BG", FirstName = "Bill", LastName = "Gates" },
    			new Employee { Id = "SJ", FirstName = "Steve", LastName = "Jobs" }
    		};
    
            var results2 = results.ConvertAll(x => x.ConvertTo<EmployeeModel>());
    
            foreach (var result in results2)
            {
                // Will display EmployeeModel instance
                Console.WriteLine(string.Format("{0} {1} {2}", result.Id, result.FirstName, result.LastName));
            }
            Console.Read();
        }
    }
