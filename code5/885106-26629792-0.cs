    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    namespace MySQLTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Service service = new Service();
    
                var task1 = service.GetCountries("1");
                var task2 = service.GetCountries("2");
                var task3 = service.GetCountries("3");
    
                Console.WriteLine("bö");
                Console.ReadLine();
            }
        }
    
        public class Service
        {
           public async Task<List<country>> GetCountries(string param)
           {
                Console.WriteLine(String.Format("{0} started.", param));
                using (worldEntities context = new worldEntities())
                {
                    Console.WriteLine(String.Format("{0} awaiting.", param));
                    List<country> countries = await context.country.ToListAsync();
    
                    Console.WriteLine(String.Format("{0} done.", param));
                    return new List<country>();
                }
            }
        }
    }
