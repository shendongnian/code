    using System;
    
    class Test
    {
        static void Main()
        {
            float a = 10f;
            float b = 0.1f;
            float c = a / b;
            double d = (double) a / (double) b;
            float e = (float) d;
            Console.WriteLine(DoubleConverter.ToExactString(c));
            Console.WriteLine(DoubleConverter.ToExactString(d));
            Console.WriteLine(DoubleConverter.ToExactString(e));
            Console.WriteLine((int) c);
            Console.WriteLine((int) d);
            Console.WriteLine((int) e);
        }
    }
