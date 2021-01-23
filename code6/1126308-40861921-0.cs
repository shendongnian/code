    class Program
    {
        static void Main(string[] args)
        {
            int circle_radius = 6; 
            double console_ratio = Convert.ToDouble(4.0 / 2.0);
            double a = console_ratio * circle_radius;
            double b = circle_radius;
            for (int y = -circle_radius; y <= circle_radius; y++)
            {
                for (double x = -console_ratio * circle_radius; x <= console_ratio * circle_radius; x++)
                {
                    double d = (x / a) * (x / a) + (y / b) * (y / b);
                    if (d > 0.90 && d < 1.2)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("\n");
            }
                       Console.Read();
        }
    }
}
