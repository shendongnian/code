    using System;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine((1.675).CustomRound(2));
                Console.WriteLine((5.41875).CustomRound(2));
                Console.WriteLine((1.67501).CustomRound(2));
                Console.WriteLine((1.67499).CustomRound(2));
                Console.ReadKey();
            }
        }
        public static class fun
        {
            //i looked at math.round with ilspy, they do something like this :-p
            private static readonly double[] pow;
            
            static fun()
            {
                int max = 16;
                pow = new double[max];
                for (int i = 0; i < max; ++i)
                    pow[i] = Math.Pow(10, i);
            }
            public static double CustomRound(this double test, int digits)
            {
                //this seem to be working! :-D
                var fun = test * pow[digits+1];
                var stuff = Math.Floor(test * pow[digits]) * pow[1];
                if ((fun-stuff) == 5)
                {
                    return stuff / pow[digits + 1];
                }
                else
                {
                    return Math.Round(test, digits, MidpointRounding.AwayFromZero);
                }
            }
        }
    }
