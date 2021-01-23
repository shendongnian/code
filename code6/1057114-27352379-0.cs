    using System;
    using System.Collections.Generic;
    
    class Program
    {
    
        static void Main()
        {
    	
            int[] arr = new int[3]; // New array with 3 elements
    	
            arr[0] = 2;
    	
    
            arr[1] = 3;
    	
            arr[2] = 5;
    	
            List<int> list = new List<int>(arr); // Copy to List
    	
            Console.WriteLine(list.Count);       // 3 elements in List
       
         }
    
    }
    Output : 3
