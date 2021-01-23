    public static Tuple<double, double> Area()
    {
        Console.WriteLine("Enter the radius of the first circle:   ");
        int r1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the radius of the second circle:   ");
        int r2 = Convert.ToInt32(Console.ReadLine());
        double pi = Math.PI;
        double result1 = pi * r1 * r1;
        double result2 = pi * r2 * r2;
        Console.WriteLine("The area of the first circle is {0}\nThe area of the second circle is {1}\n", result1, result2);
        return Tuple.Create(result1, result2);
    }
