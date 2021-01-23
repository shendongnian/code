    using System;
    using System.Diagnostics;
    using System.Linq;
    namespace ConsoleApplication1
    {
        public static class NumericExtensions
        {
            public static double RoundToSignificantFigures(this double num, int n)
            {
                if (num == 0)
                {
                    return 0;
                }
                double magnitude = Math.Pow(10, n - (int)Math.Ceiling(Math.Log10(Math.Abs(num))));
                double shifted = Math.Round(num * magnitude);
                return shifted / magnitude;
            }
            public static double RoundToSignificantFiguresWithConvert(this double num, int n)
            {
                var sigFigFormatted = num.ToString("G" + n.ToString());
                return Convert.ToDouble(sigFigFormatted);
            }
        }
        class Program
        {
            static string[] Test1(double[] numbers, int numberOfSigFigs, int numberOfDecimalPlaces)
            {
                var result = new string[numbers.Length];
                for (int i = 0; i < numbers.Length; i++)
                {
                    result[i] = numbers[i].RoundToSignificantFigures(numberOfSigFigs).ToString("F" + numberOfDecimalPlaces.ToString());
                }
                return result;
            }
            static string[] Test2(double[] numbers, int numberOfSigFigs, int numberOfDecimalPlaces)
            {
                var result = new string[numbers.Length];
                for (int i = 0; i < numbers.Length; i++)
                {
                    result[i] = numbers[i].RoundToSignificantFiguresWithConvert(numberOfSigFigs).ToString("F" + numberOfDecimalPlaces.ToString());
                }
                return result;
            }
            static void Main(string[] args)
            {
                // create an array or random numbers 
                var rng = new Random();
                var numbers = new double[100000];
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = 10000000000000000000D * (rng.NextDouble() - 0.5D);
                }
                const int numberOfSigFigs = 3;
                const int numberOfDecimalPlaces = 3;
                // make first run without time measurement
                Test1(numbers, numberOfSigFigs, numberOfDecimalPlaces);
                Test2(numbers, numberOfSigFigs, numberOfDecimalPlaces);
    
                const int numberOfIterations = 100;
                var sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < numberOfIterations; i++)
                {
                    Test1(numbers, numberOfSigFigs, numberOfDecimalPlaces);
                }
                sw.Stop();
                Console.WriteLine("Test1 elapsed {0} ms", sw.ElapsedMilliseconds.ToString());
                sw.Restart();
                for (int i = 0; i < numberOfIterations; i++)
                {
                    Test2(numbers, numberOfSigFigs, numberOfDecimalPlaces);
                }
                sw.Stop();
                Console.WriteLine("Test2 elapsed {0} ms", sw.ElapsedMilliseconds.ToString());
    
                Console.ReadKey();
            }
    
        }
    
    }
