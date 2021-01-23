    class Program
    {
        static void Main(string[] args)
        {
            Employee EmPy1 = TryCreateCmployee("111-11-111", -4.0);
            Employee EmPy2 = TryCreateCmployee("222-22-222", 7.5);
            Employee EmPy3 = TryCreateCmployee("333-33-333", 750);
        }
    
        static Employee TryCreateCmployee(string id, double hourlyWage)
        {
            try
            {
                return new Employee(id, hourlyWage);
            }
            catch (EmployeeException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
