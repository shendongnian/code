    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    class Program
    {
    	class Item
    	{
    		public int bar1 = 0;
    		public int bar2 = 0;
    		public double foobar1 = 0;
    		public double foobar2 = 0;
    	}
    
    	public static void Main ()
        {
            var items = new List<Item>();
            items.Add(new Item() { bar1 = 1, bar2 = 2, foobar1 = 1.1, foobar2 = 1.2 });
            items.Add(new Item() { bar1 = 1, bar2 = 2, foobar1 = 1.1, foobar2 = 1.2 });
            items.Add(new Item() { bar1 = 1, bar2 = 2, foobar1 = 1.1, foobar2 = 1.2 });
    
            var sum = (from p in typeof(Item).GetFields()
    		          where Type.GetTypeCode(p.FieldType) == TypeCode.Int32 || Type.GetTypeCode(p.FieldType) == TypeCode.Double
    				  group p by p into g
    				  select new { Prop=g.Key, Sum=items.Sum(s => (decimal)Convert.ChangeType(g.Key.GetValue(s), TypeCode.Decimal)) })
                      .Aggregate(new Item(), (state, next) => {  
                        next.Prop.SetValue(state, Convert.ChangeType(next.Sum, next.Prop.FieldType));
                        return state;
                      });
    
    
            Console.WriteLine("bar1: " + sum.bar1);
            Console.WriteLine("bar2: " + sum.bar2);
            Console.WriteLine("foobar1: " + sum.foobar1);
            Console.WriteLine("foobar2: " + sum.foobar2);
        }
    }
