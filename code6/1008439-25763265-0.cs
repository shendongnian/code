    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Stopwatch watch = Stopwatch.StartNew();
    
                int count = 100;
                Double min = 0;
                Double max = 10;
                Double target = 7;
                Double tolerance = 0.00000001;
                Double minAverage = target - tolerance;
                Double maxAverage = target + tolerance;
    
                Random r = new Random();
                List<Double> numbers = new List<double>();
                Double sum = 0;
                for (int i = 0; i < count; i++)
                {
                    Double d = RangedDouble(min, max, r);
                    numbers.Add(d);
                    sum += d;
                }
    
    
                int Adjustments = 0;
    
                while((sum / count < minAverage || (sum / count) > maxAverage))
                {
                    while ((sum / count) < minAverage)
                    {
                        Double oldDbl = numbers.First(d => d < minAverage);
                        Double newDbl = oldDbl + RangedDouble(minAverage - oldDbl, 10 - oldDbl, r);
    
                        numbers.Remove(oldDbl);
                        sum -= oldDbl;
                        numbers.Add(newDbl);
                        sum += newDbl;
                        Adjustments++;
                    }
    
                    while ((sum / count) > maxAverage)
                    {
                        Double oldDbl = numbers.First(d => d > maxAverage);
                        Double newDbl = oldDbl - RangedDouble(oldDbl - maxAverage, oldDbl, r);
    
                        numbers.Remove(oldDbl);
                        sum -= oldDbl;
                        numbers.Add(newDbl);
                        sum += newDbl;
                        Adjustments++;
                    }
                }
                watch.Stop();
    
                int x = 0;
                while (x < count)
                {
                    Console.WriteLine("{0:F7}  {1:F7}  {2:F7}  {3:F7}", numbers.Skip(x).Take(1).First(), numbers.Skip(x + 1).Take(1).First(), numbers.Skip(x + 2).Take(1).First(), numbers.Skip(x + 3).Take(1).First());
                    x += 4;
                }
    
                Console.WriteLine();
                Console.WriteLine(watch.ElapsedMilliseconds);
                Console.WriteLine(numbers.Average());
                Console.WriteLine(Adjustments);
                Console.ReadKey(true);
            }
    
            private static double RangedDouble(Double min, Double max, Random r)
            {
                return (r.NextDouble() * (max - min) + min);
            }
        }
    }
