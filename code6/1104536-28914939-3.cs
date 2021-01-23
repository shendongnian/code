    using MoreLinq;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    
    class Test
    {
        static void Main(string[] args)
        {
            var cars = File.ReadLines("test.txt")
                .Select(line => line.Split('|'))
                .Select(bits => new { Name = bits[0], Consumption = double.Parse(bits[1]) })
                .ToList();
            
            if (cars.Count == 0)
            {
                Console.WriteLine("No cars!");
                return;
            }
                        
            var highest = cars.MaxBy(c => c.Consumption);
            var lowest = cars.MinBy(c => c.Consumption);
    
            Console.WriteLine(
                "Highest consumption: {0}. It consumes {1}L per 100km",
                highest.Name, highest.Consumption);
            Console.WriteLine(
                "Lowest consumption: {0}. It consumes {1}L per 100km",
                lowest.Name, lowest.Consumption);
        }
    }
