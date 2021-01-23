    public class Employee
    {
        public string Name { get; set; }
        public Employee(string name)
        {
            Name = name;
        }
        public void SetName()
        {
            Console.WriteLine("Please enter a name of an employee:");
            Name = Console.ReadLine();
        }
        public void PrintName()
        {
            Console.WriteLine("The name of the employee entered was:");
            Console.WriteLine(Name);
        }
    }
