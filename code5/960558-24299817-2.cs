    using System;
    
    class Test
    {
        static void Main()
        {
            double d1 = 0.84551240822557006;
            string s = d1.ToString("r");
            double d2 = double.Parse(s);
            Console.WriteLine(s);
            Console.WriteLine(DoubleConverter.ToExactString(d1));
            Console.WriteLine(DoubleConverter.ToExactString(d2));
            Console.WriteLine(d1 == d2);
        }
    }
