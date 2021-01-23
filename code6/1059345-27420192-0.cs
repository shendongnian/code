    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var datalist= new List<Tuple<long, string, string>>();
    		datalist.Add(new Tuple<long, string, string>(123123, "xxx", "zz"));
    		datalist.Add(new Tuple<long, string, string>(444555, "ybc", "bb"));
    		datalist.Add(new Tuple<long, string, string>(444555, "abc", "aa"));
    		datalist.OrderBy(x => x.Item1).ThenBy(x => x.Item3);
    		foreach(var data in datalist)
    		{
    			Console.WriteLine("{0} {1} {2}", data.Item1,data.Item2, data.Item3);
    		}
    	}
    }
