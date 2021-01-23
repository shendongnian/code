    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Security;
    
    namespace ConsoleApplication4
    {
    	class Program
    	{
    		class N
    		{
    			public int ID { get; set; }
    			public int? Data { get; set; }
    		}
    
    		class A
    		{
    			public int ID { get; set; }
    		}
    
    		static int CodeA(List<N> ListN, List<A> ListA)
    		{
    			var c = 0;
    			foreach (var item in ListA)
    			{
    				if (ListN.Where(x => x.ID == item.ID).Any(y => y.Data != null))
    				{
    					c = ListN.Where(x => x.ID == item.ID).Min(y => y.Data).Value;
    					break;
    				}
    			}
    			return c;
    		}
    
    		static int CodeB(List<N> ListN, List<A> ListA)
    		{
    			var c = 0;
    			foreach (var item in ListA)
    			{
    				var list = ListN.Where(x => x.ID == item.ID);
    				if (list.Any(y => y.Data != null))
    				{
    					c = list.Min(y => y.Data).Value;
    					break;
    				}
    			}
    			return c;
    		}
    
    		static void Main(string[] args)
    		{
    			var listN = new List<N>
    			{
    				new N {ID = 1090, Data = 1},
    				new N {ID = 1090, Data = 3},
    				new N {ID = 1090, Data = 4},
    				new N {ID = 1089, Data = 1},
    				new N {ID = 1089, Data = 3},
    				new N {ID = 1089, Data = 4},
    				new N {ID = 1089, Data = null}
    			};
    			var listA = new List<A>
    			{
    				new A {ID = 1089},
    				new A {ID = 1090}
    			};
    			try
    			{
    				CodeA(listN, listA);
    				Console.WriteLine("No Exception");
    			}
    			catch (Exception ex)
    			{
    				Console.WriteLine("A exception: " + ex.ToString());
    			}
    			try
    			{
    				CodeB(listN, listA);
    				Console.WriteLine("No Exception");
    			}
    			catch (Exception ex)
    			{
    				Console.WriteLine("B exception: " + ex.ToString());
    			}
    			Console.ReadLine();
    		}
    	}
    
    }
