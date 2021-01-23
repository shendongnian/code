    using System;
    
    class Test
    {
        static void Main()
        {
            Random random = new Random();
            int under100 = 0;
            for (int i = 0; i < 100; i++)
            {
                double price = 100;
                double sum = 0;
                
                for (int j = 0; j < 1000; j++)
                {
                    double lowerBound = price * 0.95;
                    double upperBound = price * 1.05;
                    double sample = random.NextDouble();
                    sum += sample;
                    price = sample * (upperBound - lowerBound) + lowerBound;                
                }
                Console.WriteLine("Average: {0:f2} Price: {1:f2}", sum / 1000, price);
                if (price < 100)
                {
                    under100++;
                }
            }
            Console.WriteLine("Samples with a final price < 100: {0}", under100);
        }
    }
