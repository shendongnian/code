    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace StackOverFlowConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Item> list1 = new List<Item>()
                {
                    new Item(){date = DateTime.Today, value=100},
                    new Item(){date = DateTime.Today.AddDays(-1), value=100}
                };
                List<Item> list2 = new List<Item>()
                {
                    new Item(){date = DateTime.Today, value=50}               
                };
    
                var result = (from x in list1 select new Item() { date = x.date, value = x.value - (from y in list2 where x.date.Equals(y.date) select y.value).FirstOrDefault() }).ToList();
    
            }
    
            class Item
            {
               
                public DateTime date { get; set; }
                public double value { get; set; }
            }
    
           
        }
    }
