    public static void Main(string[] args)
    {
        int salary = 1;
        int w;
        Console.WriteLine("Enter number of days worked: ");
        w = Convert.ToInt32(Console.ReadLine());
        salary = salary * Math.Pow(2, Math.Min(w - 1, 14));
        Console.WriteLine("The salary is: ${0}.00", salary);
        Console.WriteLine("Press any key to close....");
        Console.ReadKey();
    }
