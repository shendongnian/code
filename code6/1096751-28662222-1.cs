    namespace employee
    {
        public class employeeApp
        {
            public static void Main()
            {
                EmployeeProgram.employee Employee = new EmployeeProgram.employee(321, "Alex", "1/02/15", 2500, "Corporate grunt", "Sales");
                Employee.Print();
            }
    
        }
    }
