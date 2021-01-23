    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ExampleDeletion
    {
        class Program
        {
            public class Company
            {
                public string Name { get; set; }
                public Boss CEO { get; set; }
    
                ~Company()
                {
                    Console.WriteLine("Company destroyed: " + Name);
                }
            }
            public class Boss
            {
                public string Name { get; set; }
    
                ~Boss()
                {
                    Console.WriteLine("Boss destroyed: " + Name);
                }
            }
    
            static void Main(string[] args)
            {
                List<Company> companies = new List<Company>();
    
                Add(ref companies);
                Remove(ref companies);
    
                GC.Collect();
    
                Console.ReadLine();
            }
    
            static private void Add(ref List<Company> companies)
            {
                companies.Add(
                    new Company()
                    {
                        Name = "Greiner",
                        CEO = new Boss()
                        {
                            Name = "Hugo"
                        }
                    });
            }
    
            static private void Remove(ref List<Company> companies)
            {
                Company comp = companies.FirstOrDefault();
                companies.Remove(comp);
            }
        }
    }
