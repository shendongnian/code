    public static void Main(string[] args)
            {
                int salary = 1;
                int w;
                int amountEarned = 0;
    
                Console.WriteLine("Enter number of days worked: ");
                w = Convert.ToInt32(Console.ReadLine());
    
                for (int wage = 1; wage < w + 1; wage++)
                {
                    var currentDaySalary = (salary * ((wage*100)/100));
                    amountEarned += currentDaySalary;
                }
                Console.WriteLine("The salary is: ${0}.00", amountEarned);
                Console.WriteLine("Press any key to close....");
                Console.ReadKey();
    
            }
