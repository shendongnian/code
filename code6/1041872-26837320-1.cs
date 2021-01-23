    namespace ConsoleApplication36
    {
    class Program
    {
        static void Main(string[] args)
        {
            float Salary = 300;
            float a = 0;
            if (Salary <= 100)
            {
                a = Salary * 0; // a = amount paid
            }
            else if (Salary <= 200)
            {
                a = Salary * 5 / 100;
            }
            else if (Salary <= 500)
            {
                a = Salary * 10 / 100;
            }
            else
            {
                a = Salary*15/100;
            }
            Console.WriteLine("He Pays " + a);
            Console.In.ReadLine();
        }
    }
    }
