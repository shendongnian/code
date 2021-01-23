    class Program
    {
        // all the code is unchecked, overflow is not important.
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            Random rand = new Random();
            // Check random numbers (positive and negative) and see if they are the same on both function.
            for (int i = 0; i < 5; i++)
            {
                double num = (rand.NextDouble() + rand.Next(10000)) * (rand.NextDouble() >= 0.5 ? 1 : -1);
                Console.WriteLine("TweakedCast({0}) = {1}", num, TweakedCast(num));
                Console.WriteLine("Math.Floor({0}) = {1}", num, Floor(num));
                Console.WriteLine();
            }
            Console.WriteLine("TweakedCast({0}) = {1}", double.PositiveInfinity, TweakedCast(double.PositiveInfinity));
            Console.WriteLine("Math.Floor({0}) = {1}", double.PositiveInfinity, Floor(double.PositiveInfinity));
            Console.WriteLine();
            Console.WriteLine("TweakedCast({0}) = {1}", double.NegativeInfinity, TweakedCast(double.NegativeInfinity));
            Console.WriteLine("Math.Floor({0}) = {1}", double.NegativeInfinity, Floor(double.NegativeInfinity));
            Console.WriteLine();
            Console.WriteLine("TweakedCast({0}) = {1}", double.NaN, TweakedCast(double.NaN));
            Console.WriteLine("Math.Floor({0}) = {1}", double.NaN, Floor(double.NaN));
            Console.WriteLine();
            double a = rand.NextDouble() + rand.Next(10000);
            double b = -(rand.NextDouble() + rand.Next(10000));
            Console.WriteLine("a: {0}, b: {1}", a, b);
            Console.WriteLine("After 25 million iteration of both a and b on both methods, the result is:");
            sw.Start();
            for (int i = 0; i < 50000000; i++)
            {
                TweakedCast(a);
                TweakedCast(b);
            }
            sw.Stop();
            Console.WriteLine("TweakedCast time: {0}", sw.ElapsedMilliseconds);
            
            sw.Restart();
            for (int i = 0; i < 50000000; i++)
            {
                Floor(a);
                Floor(b);
            }
            sw.Stop();
            Console.WriteLine("Math.Floor time: {0}", sw.ElapsedMilliseconds);
            Console.ReadKey();
        }
        static int TweakedCast(double num)
        {
            int ret = (int)num;
            if (ret > num)
                ret--;
            return ret;
        }
        static int Floor(double num)
        {
            return (int)Math.Floor(num);
        }
    }
