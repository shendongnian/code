    static void Main(string[] args)
    {
        const double eps = 0.001;
        int n = 1;
        double x = 1.0 / (n * n);
        double sum = 0.0;
        while (x > eps)
        {
            sum += x;
            n++;
            x = 1.0 / (n*n);
            Console.WriteLine(sum);
        };
        Console.Write("\nSum: {0}", sum);
        Console.ReadLine();
    }
