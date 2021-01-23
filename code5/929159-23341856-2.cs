    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class LinqGroupDemo
    {
        static public void Main(string[] args)
        {
            var query =
                from column in GetSource()
                group column by new {column.LocId, column.SecId} into g
                orderby g.Key.LocId, g.Key.SecId
                select new
                {
                    LocId = g.Key.LocId,
                    SecId = g.Key.SecId,
                    Columns = g
                };
    
            foreach (var key in query)
            {
                Console.WriteLine("LocId:{0}, SecId:{1}",
                                  key.LocId,
                                  key.SecId);
    
                foreach (var column in key.Columns)
                {
                    Console.WriteLine("  StartElevation:{0}, EndElevation:{1}",
                                      column.StartElevation,
                                      column.EndElevation);
                }
            }
        }
    
        static private List<Column> GetSource()
        {
            return new List<Column>
            {
                new Column { LocId = 1 , SecId = 1, StartElevation = 0, EndElevation = 160 },
                new Column { LocId = 1 , SecId = 1, StartElevation = 160, EndElevation = 320 },
                new Column { LocId = 1 , SecId = 2, StartElevation = 320, EndElevation = 640 },
                new Column { LocId = 2 , SecId = 1, StartElevation = 0, EndElevation = 160 },
                new Column { LocId = 2 , SecId = 2, StartElevation = 160, EndElevation = 320 }
            };
        }
    }
    
    public class Column
    {
        public int LocId { get; set; }
        public int SecId { get; set; }
        public double StartElevation { get; set; }
        public double EndElevation { get; set; }
    }
