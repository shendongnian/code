    namespace Temp1
    {
        using System;
        using System.IO;
    
        public class GlobalVariables
        {
            /// <summary>
            /// Wage per hour
            /// </summary>
            public static double WagePerHour = 7.5;
        } 
    
        public class Program
        {
            private static void LoadEmployees()
            {
                // Get the name of the employee
                Console.WriteLine("Name of employee: ");
                string employee = Console.ReadLine();
    
                // Get the file path
                string filePath = string.Format(
                    @"{0}\{1}",
                    Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                    "Employees.txt");
    
                // Check if the file does not exist and create it
                if (!File.Exists(filePath))
                {
                    // Generate sample employees
                    string[] employees = { "Emp1", "Emp2", "Emp3", "Emp4" };
    
                    // Write all the lines in the file
                    File.WriteAllLines(filePath, employees);
                }
    
                // Read all the lines from the file
                string[] currentEmployees = File.ReadAllLines(filePath);
    
                // Check the employee name
                NameCheck(currentEmployees, employee);
            }
    
            /// <summary>
            /// Do the name check recursively so you don’t keep loading the file all the time
            /// </summary>
            /// <param name="names">Array of all the employee names</param>
            /// <param name="nameToFind">Name to find</param>
            /// <param name="currentPosition">Current position in the array</param>
            public static void NameCheck(string[] names, string nameToFind, int currentPosition = 0)
            {
                if (currentPosition == nameToFind.Length - 1)
                {
                    Console.WriteLine("That name is not in the employee database, try again:");
                }
                else if (string.Compare(names[currentPosition], nameToFind, StringComparison.InvariantCulture) != 0)
                {
                    currentPosition++;
                    NameCheck(names, nameToFind, currentPosition);
                }
            }
    
            /// <summary>
            /// Calculate pay roll
            /// </summary>
            /// <param name="hours"></param>
            /// <param name="wage"></param>
            /// <returns></returns>
            private static double PayRoll(double hours, double wage)
            {
                return hours * wage;
            }
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="args"></param>
            private static void Main(string[] args)
            {
                Console.WriteLine("                                   PAYROLL");
                Console.WriteLine("--------------------------------------------------------------------------------");
    
                // Load employees and check if the employee is in the list
                LoadEmployees();
    
                // Get the number of hours worked
                Console.WriteLine("Number of hours worked this week: ");
                double hours = Convert.ToDouble(Console.ReadLine());
    
                // Get the current pay
                double pay = PayRoll(hours, GlobalVariables.WagePerHour);
    
                Console.WriteLine("Pay before tax for this employee is £" + pay);
                Console.ReadLine();
            }
        }
    }
