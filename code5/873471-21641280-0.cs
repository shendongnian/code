    using System;
    
    public class Test
    {
    	public static void Main()
    	{
    
    	  string str =  "4R|1|^^^100^CL_S|122.13|38||||F|||20070628114638" ;
    	
    	
    	    int a_first = str.IndexOf("^^^100") + "^^^100".Length + 1;
    	    string str_a = str.Substring(a_first);
    	    string[] words_a = str_a.Split('|');
    	    string CL_S = words_a[1];
    	
    	    Console.WriteLine(a_first);
    	    Console.WriteLine(str_a);
    	    Console.WriteLine(CL_S);
    	    
    	    Console.WriteLine();
    	    
    	    
    	    int b_first = str.IndexOf("^^^101") + "^^^101".Length + 1;
    	    string str_b = str.Substring(b_first);
    	    string[] words_b = str_b.Split('|');
    	    string NA = words_b[1];
    	    
    	    Console.WriteLine(b_first);
    	    Console.WriteLine(str_b);
    	    Console.WriteLine(NA);
    	}
    	
    }
