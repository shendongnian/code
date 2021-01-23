    static void Main(string[] args)
    {
        const double eps = 0.001;
        int n = 1;
        double sum = 0.0;
        while (true)
        {
            double x = 1.0 / (n * n);
            if (x <= eps)
                break;
            sum += x;
            n++;
            Console.WriteLine(sum);
        };
        Console.Write("\nSum: {0}", sum);
        Console.ReadLine();
    }
