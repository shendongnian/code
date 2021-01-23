    namespace N
    {
        using System;
        class Program
        {
            static void Main()
            {
                X value1 = (X)Enum.Parse(typeof(X), "CPU");
                X value2;
                Enum.TryParse("CPU", out value2);
                Console.WriteLine(value1);
                Console.WriteLine(value2);
                Console.ReadKey();
            }
        }
        public enum X
        {
            CPU
        }
    }
