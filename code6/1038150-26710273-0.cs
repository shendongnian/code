    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace DynamicListTest
    {
       internal class Program
       {
          private static void Main(string[] args)
          {
             var dynamicObjects = GetDynamicObjects();
    
             var itemsToPrint = dynamicObjects
                .Where(item => item.Age > 30);
    
             foreach (var item in itemsToPrint)
             {
                Console.WriteLine(item);
             }
    
             Console.ReadKey();
          }
    
          private static List<dynamic> GetDynamicObjects()
          {
             return new List<dynamic>()
             {
                new { Name = "A", Age = 10 },
                new { Name = "B", Age = 20 },
                new { Name = "C", Age = 30 },
                new { Name = "D", Age = 40 },
                new { Name = "E", Age = 50 },
             };
          }
       }
    }
