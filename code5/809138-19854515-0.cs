    using System;
    using System.Collections.Generic;
    namespace dimensionrandomwalk
    {
        class MainClass
        {
            public static void Main (string[] args)
            {
                Random rnd = new Random();
                int[] x;
                x = new int[500];
                for (int i = 0; i < 500; i++){
                    int L = rnd.Next (0, 2);
                    
                    x[i] = (L==0) ? -1 : 1;
                   
                    Console.WriteLine (x[i]);
                }
                
                int total_value = 0;
                for (int i = 0; i < 500; i++
                    total_value += x[i];
                
                Console.WriteLine ("Total: " + total_value);
            }
        }
    }
