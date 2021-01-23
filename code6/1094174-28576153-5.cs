    public class EmployeeTest
    {
        public static void Main(string[] args)
        {
            //create Employee object myEmployee and pass string to constructor
            var myEmployee01 = new Employee("Bob");
            var myEmployee02 = new Employee("Alice");
            myEmployee01.SetName();
            myEmployee02.SetName();
            myEmployee01.PrintName();
            myEmployee02.PrintName();
            //Console.WriteLine("The name of the first employee was: ", myEmployee01.Name);
            //Console.WriteLine();
            //Console.WriteLine("The name of the second employee was: ", myEmployee02.Name);
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
