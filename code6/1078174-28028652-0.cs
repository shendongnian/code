    class Program
    {
        static void Main()
        {
            Console.Write("Enter x: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Enter y: ");
            double y = double.Parse(Console.ReadLine());
            // <= 2 is outside the brackets, not inside
            bool insideCircle = Math.Sqrt((x * x) + (y + y)) <= 2;
        }
    }
