    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Script.Serialization;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var objs = new Shift[] {
                    new Shift {Start= DateTime.Parse("1/1/2000 18:00:00"), FirstName= "John", LastName= "Doe"},
                    new Shift {Start= DateTime.Parse("1/1/2000 18:00:00"), FirstName= "Bob", LastName= "Doe"},
                    new Shift {Start= DateTime.Parse("1/1/2000 18:00:00"), FirstName= "Jack", LastName= "Doe"},
                    new Shift {Start= DateTime.Parse("1/1/2000 22:00:00"), FirstName= "John", LastName= "Doe"},
                    new Shift {Start= DateTime.Parse("1/1/2000 22:00:00"), FirstName= "Bob", LastName= "Doe"},
                    new Shift {Start= DateTime.Parse("1/1/2000 22:00:00"), FirstName= "Jack", LastName= "Doe"},
                    new Shift {Start= DateTime.Parse("2/1/2000 10:00:00"), FirstName= "John", LastName= "Doe"},
                    new Shift {Start= DateTime.Parse("2/1/2000 10:00:00"), FirstName= "Bob", LastName= "Doe"},
                    new Shift {Start= DateTime.Parse("2/1/2000 10:00:00"), FirstName= "Jack", LastName= "Doe"},
                    new Shift {Start= DateTime.Parse("2/1/2000 14:00:00"), FirstName= "John", LastName= "Doe"},
                    new Shift {Start= DateTime.Parse("2/1/2000 14:00:00"), FirstName= "Bob", LastName= "Doe"},
                    new Shift {Start= DateTime.Parse("2/1/2000 14:00:00"), FirstName= "Jack", LastName= "Doe"}
                };
    
                var dates = objs
                    .GroupBy(i => i.Start.Date)
                    .Select(i => new
                    {
                        Date = i.Key,
                        Times = i.GroupBy(s => s.Start.TimeOfDay).Select(s => new
                        {
                            Time = s.Key,
                            People = s.Select(ss => new { ss.FirstName, ss.LastName })
                        })
                    });
    
                Console.ReadLine();
            }
        }
    
        class Shift
        {
            public DateTime Start { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
