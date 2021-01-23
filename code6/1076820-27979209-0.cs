    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json.Linq;
    
    public class Employee
    {
        public string EmployeeNumber { get; set; }
        public string title { get; set; }
        public string Name { get; set; }
        
        public JProperty ToJProperty()
        {
            return new JProperty(EmployeeNumber,
                new JObject {
                    { "title", title },
                    { "Name", Name }
                });
        }
    }
    
    public class EmployeeRecords
    {
        public List<Employee> Employees { get; set; }
        
        public JObject ToJObject()
        {
            var obj = new JObject();
            foreach (var employee in Employees)
            {
                obj.Add(employee.ToJProperty());
            }
            return new JObject {
                new JProperty("EmployeeRecords", obj)
            };
        }
    }
    
    class Test
    {
        static void Main()
        {
            var records = new EmployeeRecords {
                Employees = new List<Employee> {
                    new Employee {
                        EmployeeNumber = "12",
                        title = "Mr",
                        Name = "John"
                    },
                    new Employee {
                        EmployeeNumber = "35",
                        title = "Mr",
                        Name = "Json"
                    },
                }
            };
            Console.WriteLine(records.ToJObject());
        }    
    }
