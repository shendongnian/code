    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleSandbox
    {
    class Program
    {
        static void Main(string[] args)
        {
            var vm = new ViewModel();
            var lookupEmployees = vm.GetAllOrderedByName();
            foreach (var group in lookupEmployees)
            {
                Console.WriteLine(group.Key);
                foreach (var employee in group)
                {
                    Console.WriteLine("\t"+employee);
                }
            }
            Console.Read();
        }
    }
    public class ViewModel
    {
        public ViewModel()
        {
            //Fill Employees
            Employees = new List<Employee>
            {
                new Employee{ FirstName = "Jordy", LastName = "Eijk van"},
                new Employee{ FirstName = "Jon", LastName = "Skeet"},
                new Employee{ FirstName = "John", LastName = "Doe"},
                new Employee{ FirstName = "Jane", LastName = "Doe"},
                new Employee{ FirstName = "Jack", LastName = "Ripper the"}
            };
        }
        public List<Employee> Employees { get; set; }
        /// <summary>
        /// Get the Employees by name
        /// </summary>
        /// <returns></returns>
        public ILookup<string, Employee> GetAllOrderedByName()
        {
            return Employees
                .OrderBy(e=>e.LastName)
                .ThenBy(e=>e.FirstName)
                .ToLookup(e => e.LastName.Substring(0, 1), StringComparer.CurrentCultureIgnoreCase);
        }
    }
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1}", LastName, FirstName);
        }
    }
    }
