    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
    	public class objTest
    	{
    		public int index { get; set; }
    		public string name { get; set; }
    
    		public override bool Equals(object other)
    		{
    			objTest o = other as objTest;
    			return o != null && o.index == index;
    		}
    		public override int GetHashCode()
    		{
    			return index.GetHashCode();
    		}
    	}
    	static void Main(string[] args)
    	{
    		List<objTest> L1 = new List<objTest>();
    		L1.Add(new objTest { index = 1, name = "ALAN" });
    		L1.Add(new objTest { index = 2, name = "bill" });
    		L1.Add(new objTest { index = 3, name = "clive" });
    		L1.Add(new objTest { index = 4, name = "dave" });
    		L1.Add(new objTest { index = 5, name = "ewan" });
    
    		List<objTest> L2 = new List<objTest>();
    		L2.Add(new objTest { index = 11, name = "ALAN" });
    		L2.Add(new objTest { index = 12, name = "bill" });
    		L2.Add(new objTest { index = 13, name = "clive" });
    		L2.Add(new objTest { index = 14, name = "dave" });
    		L2.Add(new objTest { index = 1, name = "ALAN2" });
    		//THIS HAS NO RESULTS
    		var L3 = L1.Intersect(L2);
    	}
    }
