    namespace Test
    {
    	using System;
    	using System.Collections.Generic;
    	using System.Text.RegularExpressions;
    
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			List<string> inputdata = new List<string> ();
    			List<TimeSpan> outputdata = new List<TimeSpan> ();
    
    			string input = null;
    			while ((input = Console.ReadLine ()) != string.Empty) {
    				inputdata.Add (input);
    				TimeSpan t = new TimeSpan (11, 0, 0) + new TimeSpan (0, Convert.ToInt32 (Regex.Match (input, "\\d+").ToString ()), 0);
    				outputdata.Add (t);
    			}
    
    			for (int i = 0; i < inputdata.Count; i++) {
    				Console.WriteLine ("Inputdata: {0}, Outputdata: {1}", inputdata [i], outputdata [i].ToString ());
    			}
    		}
    	}
    }
