    namespace Test
    {
    	using System;
    	using System.Collections.Generic;
    
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			List<int> data = new List<int> ();
    			data.AddRange (new int[] { 2, 2, 2, 3, 3, 4, 4, 4, 4 });
    
    			int instance_counter = 0;
    			int previous_end = 0;
    			for (int i = 0; i < data.Count - 1; i++) {
    				instance_counter++;
    				if (data [i] != data [i + 1]) {
    					if (instance_counter > 2) {
    						for (int j = previous_end; j < i + 1; j++) {
    							data [j] = 0;
    						}
    						previous_end = i + 1;
    					}
    					instance_counter = 0;
    					previous_end = i + 1;
    				}
    			}
    			if (instance_counter > 0) {
    				for (int j = previous_end; j < data.Count; j++) {
    					data [j] = 0;
    				}
    			}
    			foreach (int x in data) {
    				Console.WriteLine (x);
    			}
    		}
    	}
    }
