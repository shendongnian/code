    class Program
    {
        static void Main(string[] args)
        {
            Tuple<int, string, double, string> emp = GetEmployeeInfo();
            Console.WriteLine("Emplooyee Id :: " + emp.Item1);
            Console.WriteLine("Employee Name :: " + emp.Item2);
            Console.WriteLine("Employee Salary :: " + emp.Item3);
            Console.WriteLine("Employee Address :: " + emp.Item4);
        }
        static Tuple<int, string, double, string> GetEmployeeInfo()
        {
            Tuple<int, string, double, string> employee;
            employee = new Tuple<int, string, double, string>(1001, "Uthaiah Bollera", 4500000.677, "Bangalore Karnataka!");
            return employee;
        }
    }
