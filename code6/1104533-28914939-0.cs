    using System;
    using System.Globalization;
    using System.IO;
    
    class Test
    {
        static void Main(string[] args)
        {
            double highest = double.NegativeInfinity;
            double lowest = double.PositiveInfinity;
    
            string nameHighest= "";
            string nameLowest= "";
    
            foreach (var line in File.ReadLines("test.txt"))
            {
                string[] temp = line.Split('|');
                string name = temp[0];
                double consumption = double.Parse(
                    temp[1],
                    CultureInfo.InvariantCulture);
    
                if (consumption > highest)
                {
                    highest = consumption;
                    nameHighest = name;
                }
    
                if (consumption < lowest)
                {
                    lowest = consumption;
                    nameLowest = name;
                }
            }
    
            Console.WriteLine(
                "Highest consumption: {0}. It conumes {1}L per 100km",
                nameHighest, highest);
            Console.WriteLine(
                "Lowest consumption: {0}. It conumes {1}L per 100km",
                nameLowest, lowest);
        }
    }
