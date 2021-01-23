    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
    }
    class Program
    {
        static void Main(string[] args) {
            List<Employee> emloyeelist = new List<Employee>();
    
            emloyeelist.Add(new Employee() { ID = 1, Name = "Seema", Salary = 10000 });
            emloyeelist.Add(new Employee() { ID = 2, Name = "Arun", Salary = 20000 });
            emloyeelist.Add(new Employee() { ID = 3, Name = "Nayana", Salary = 30000 });
            emloyeelist.Add(new Employee() { ID = 4, Name = "Nayana", Salary = 12000 });
            emloyeelist.Add(new Employee() { ID = 5, Name = "Raman", Salary = 55000 });
    
            foreach (Employee emp in emloyeelist)
            {
                if (emp.Salary > 20000)
                {
                    Console.WriteLine(emp.Name +" "+"\t"+"has salry"+"\t"+ " " + emp.Salary);
                }
            }
        }
    }  
