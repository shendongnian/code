    using System;
    using System.Linq;
					
    public class Program {
	    public static void Main() {
		
    		var result = s2.ToCharArray().Intersect(s1.ToCharArray()).Count() == s1.Length;
		
    		Console.WriteLine("LANE/CLEAN: {0}", Test("LANE", "CLEAN"));
    		Console.WriteLine("AGED/CAGED: {0}", Test("AGED", "CAGED"));
    		Console.WriteLine("AGED/RAGE: {0}", Test("AGED", "RAGE"));
		
    	}
	
    	public static bool Test(string s1, string s2) {	
		
    		return s2.ToCharArray().Intersect(s1.ToCharArray()).Count() == s1.Length;		
			
    	}
    }
    // Results:
    //
    // LANE/CLEAN: True
    // AGED/CAGED: True
    // AGED/RAGE: False
