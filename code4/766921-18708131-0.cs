    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace dlinq1
    {
        class Thing
        {
            public int ID { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var things = new List<Thing>();
                for(int x=0;x<10;x++)
                {
                    things.Add(new Thing{ID=x%2}); //0,1,0,1,0,1,0,1,0,1
                }
                var result = things.AsQueryable().Select("ID").Distinct();
                foreach (var r in result)
                {
                    Console.WriteLine(r);
                }
                Console.ReadLine(); //produces 0, 1
            }
        }
    
        public static class DynamicQueryableExtras
        {
            public static IQueryable Distinct(this IQueryable q)
            {
                var call = Expression.Call(typeof(Queryable),
                                           "Distinct",
                                           new Type[] { q.ElementType },
                                           q.Expression);
                return q.Provider.CreateQuery(call);
            }
        }
    }
