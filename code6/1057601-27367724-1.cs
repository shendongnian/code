    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication
    	{
    	public class Class1
    		{
    		public static void Main(string[] args)
    			{
    			IEnumerable<QuantityDate> quantityDates = GetQuantityDates();//I'm sure you already have some way of retrieving these, via EF or Linq to SQL etc.
    			var results = quantityDates.Where(qd => qd.Qty < 0).CombineResults(); //This is the main Linq expression
    			foreach (var result in results)
    				{
    				Console.WriteLine("From Date: {0} To Date: {1}", result.FromDate, result.ToDate);
    				}
    			Console.WriteLine("Press any key to exit.");
    			Console.ReadKey();
    			}
    
    		//Just to see the data for the moment. You'll probably get this data via EF or Linq to SQL
    		public static List<QuantityDate> GetQuantityDates()
    			{
    			List<QuantityDate> seed = new List<QuantityDate>()
    			{
    			new QuantityDate() { EventDate = new DateTime(2014, 2, 3), Qty = 6 },
    			new QuantityDate() { EventDate = new DateTime(2014, 2, 4), Qty = -1 },
    			new QuantityDate() { EventDate = new DateTime(2014, 2, 5), Qty = -2 },
    			new QuantityDate() { EventDate = new DateTime(2014, 2, 6), Qty = 2 },
    			new QuantityDate() { EventDate = new DateTime(2014, 2, 7), Qty = -1 },
    			new QuantityDate() { EventDate = new DateTime(2014, 2, 8), Qty = -2 },
    			new QuantityDate() { EventDate = new DateTime(2014, 2, 9), Qty = -3 },
    			new QuantityDate() { EventDate = new DateTime(2014, 2, 10), Qty = 5 }
    			};
    			return seed;
    			}
    		}
    	public static class Extensions
    		{
    
    		//This is where the magic happens, and we combine the results
    		public static List<OutOfStockRange> CombineResults(this IEnumerable<QuantityDate> input)
    			{
    			List<OutOfStockRange> output=new List<OutOfStockRange>();
    			OutOfStockRange lastEntered = null;
    			foreach(var qd in input.OrderBy(qd => qd.EventDate))
    			 {
    				 if(lastEntered != null && lastEntered.ToDate.AddDays(1) == qd.EventDate)
    				 {
    					 lastEntered.ToDate = qd.EventDate;
    				 }
    				 else
    				 {
    					 lastEntered =new OutOfStockRange(){FromDate = qd.EventDate, ToDate = qd.EventDate};
    					 output.Add(lastEntered);
    				 }
    			}
    			return output;
    		}
    		}
    
    	//This class represents the input data
    	public class QuantityDate
    		{
    		public DateTime EventDate { get; set; }
    		public int Qty { get; set; }
    		}
    
    	//This class represents the output data
    	public class OutOfStockRange
    		{
    		public DateTime FromDate { get; set; }
    		public DateTime ToDate { get; set; }
    		}
    	}
