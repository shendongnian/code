         using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    
    namespace ConsoleApplication1
    {
    	public class CompareLines : IComparer<string>
    	{
    		public string IncomingFormat { get; set; }
    
    		public CompareLines()
    		{
    			IncomingFormat = "MMddyyyy";
    		}
    
    		public int Compare(string first, string second)
    		{
    
    			first = first.Replace("\t", "");
    			second = second.Replace("\t", "");
    
    			var date1 = DateTime.ParseExact(first, IncomingFormat, CultureInfo.InvariantCulture);
    			var date2 = DateTime.ParseExact(second, IncomingFormat, CultureInfo.InvariantCulture);
    
    			return date1.CompareTo(date2);
    		}
    	}
    
    	internal class Program
    	{
    		private static void Main()
    		{
    			var comparer = new CompareLines();
    
    			int result;
    			string date1, date2;
    			const string dataFormat = "MM\tdd\tyyyy";
    
    			date1 = DateTime.Parse("1/1/2000").ToString(dataFormat);
    			date2 = DateTime.Parse("1/1/2000").ToString(dataFormat);
    			result = comparer.Compare(date1, date2);
    			Debug.Assert(result == 0);
    			Console.WriteLine("{0} compare {1} = {2}", date1, date2, result);
    
    			date1 = DateTime.Parse("1/1/2000").ToString(dataFormat);
    			date2 = DateTime.Parse("1/2/2000").ToString(dataFormat);
    			result = comparer.Compare(date1, date2);
    			Debug.Assert(result == -1);
    			Console.WriteLine("{0} compare {1} = {2}", date1, date2, result);
    
    			date1 = DateTime.Parse("1/2/2000").ToString(dataFormat);
    			date2 = DateTime.Parse("1/1/2000").ToString(dataFormat);
    			result = comparer.Compare(date1, date2);
    			Debug.Assert(result == 1);
    			Console.WriteLine("{0} compare {1} = {2}", date1, date2, result);
    
    			Console.ReadLine();
    		}
    	}
    }
