    namespace ConsoleApplication
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
    
        class Program
        {
            static void Main(string[] args)
            {
                var sourceList = new List<Supplier>()
                {
                    new Supplier() {Status = true, Supplier1 = "Z99"},
                    new Supplier() {Status = true, Supplier1 = "F32"},
                    new Supplier() {Status = false, Supplier1 = "B2"},
                    new Supplier() {Status = true, Supplier1 = "C3"},
                    new Supplier() {Status = true, Supplier1 = "B1"},
                    new Supplier() {Status = true, Supplier1 = "A33"},
                    new Supplier() {Status = true, Supplier1 = "A3"},
                    new Supplier() {Status = true, Supplier1 = "C1"},
                };
    
                var list = sourceList.Where(c => c.Status.Equals(true)).OrderBy(c => c.Supplier1).GroupBy(c => c.Supplier1.Substring(0, 1)).ToList();
                Console.ReadLine();
            }
       }
    
        public class Supplier
        {
            public bool Status { get; set; }
            public string Supplier1 { get; set; }
        }
    }
