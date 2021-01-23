    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee { FirstName = "John", LastName = "Doe" };
            emp.PrintFullName();
    
            PartTime pt = new PartTime  { FirstName = "Jane", LastName = "Doe" };
    
            float pay=pt.CalcPay(10, 8);
            pt.PrintFullName();  
    
            Console.WriteLine("Pay {0}", pay);
            Console.ReadKey();
        }
    }
    
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public void PrintFullName()
        {
            Console.WriteLine("Full Name {0} {1} ", FirstName, LastName);
        }
    }
    
    public class PartTime : Employee
    {
        public float CalcPay(int hours, int rate)
        {
            return hours * rate;
        }
    }
